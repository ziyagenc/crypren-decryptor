using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace CryprenDecryptor
{
    public partial class MainForm : Form
    {
        private List<string> encryptedFiles;
        private static string password = "";
        private static char[] alphabet =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
            'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '!', '@', '#', '$', '%', '&', '*', '-', '=', '.', '+', '?'
        };

        private static int maxIndex = 7;
        private static char[] guess = new char[8];
        private static bool firstGuess = true;
        private static byte[] buffer = new byte[16];
        private static byte[] pdfSignature = { 0x25, 0x50, 0x44, 0x46 };
        byte[] key;
        byte[] iv;
        static int counter = 0;
        static Stopwatch sw = new Stopwatch();

        #region FORM FUNCTIONS

        public MainForm()
        {
            InitializeComponent();
            encryptedFiles = new List<string>();
            openFileDialog1.Filter = "Crypren Files (*.enc) | *.enc";
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                if (addFile(file))
                {
                    string logEntry = String.Format("{0}  Added file: {1}", DateTime.Now.ToString(), file);
                    addLog(logEntry);
                }
            }
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string logEntry = String.Format("{0}  Scanning folder: {1}", DateTime.Now.ToString(), folderBrowserDialog1.SelectedPath);
                addLog(logEntry);

                try
                {
                    var files = GetFiles(folderBrowserDialog1.SelectedPath, "*.enc");

                    foreach (string file in files)
                    {
                        addFile(file);
                    }
                }
                catch
                {
                    logEntry = String.Format("{0}  Error occurred while scanning: {1}", DateTime.Now.ToString(), folderBrowserDialog1.SelectedPath);
                    addLog(logEntry);
                }

                logEntry = String.Format("{0}  Finished scanning folder.", DateTime.Now.ToString());
                addLog(logEntry);
            }
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            string logEntry = String.Format("{0}  Scanning all drives for files: *.enc", DateTime.Now.ToString());
            addLog(logEntry);

            foreach (string letter in Directory.GetLogicalDrives())
            {
                var files = GetFiles(letter, ".enc");

                foreach (string file in files)
                {
                    try
                    {
                        string filenameWithEnc = file;
                        addFile(filenameWithEnc);
                    }
                    catch
                    {
                        Console.WriteLine("Error occurred while accessing: {0}", file);
                        continue;
                    }
                }
            }

            logEntry = String.Format("{0}  Finished scanning.", DateTime.Now.ToString());
            addLog(logEntry);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string logEntry;

            if(encryptedFiles.Count == 0)
            {
                logEntry = String.Format("{0}  No files to decrypt. Did you perfom a scan or manually add a file?", DateTime.Now.ToString());
                addLog(logEntry);
                return;
            }
            
            string candidateFile = GetCandidateFile();

            if (candidateFile.Equals(String.Empty))
            {
                logEntry = String.Format("{0}  Could not find a candidate file.", DateTime.Now.ToString());
                addLog(logEntry);

                return;
            }

            logEntry = String.Format("{0}  Candidate file: {1}", DateTime.Now.ToString(), candidateFile);
            addLog(logEntry);

            try
            {
                using (FileStream fsCrypt = File.OpenRead(candidateFile))
                {
                    fsCrypt.Read(buffer, 0, 16);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Unhandled Exception");
                logEntry = String.Format("{0}  Exception occurred while reading candidate file.", DateTime.Now.ToString(), candidateFile);
                addLog(logEntry);
                return;
            }

            logEntry = String.Format("{0}  Started brute-force attack to find secret password.", DateTime.Now.ToString());
            addLog(logEntry);

            sw.Start();
            BruteForce(0);

            if (password == "")
            {
                logEntry = String.Format("{0}  Brute force finished. Could not find the password.", DateTime.Now.ToString());
                addLog(logEntry);
                return;
            }

            logEntry = String.Format("{0}  Found password: {1}", DateTime.Now.ToString(), password);
            addLog(logEntry);

            key = new UnicodeEncoding().GetBytes(password);
            iv = new UnicodeEncoding().GetBytes(password);

            logEntry = String.Format("{0}  Started decrypting files.", DateTime.Now.ToString());
            addLog(logEntry);
            logEntry = String.Format("{0}  Number of files: {1}", DateTime.Now.ToString(), encryptedFiles.Count);
            addLog(logEntry);

            foreach (var item in listBoxEncFiles.Items)
            {
                MemoryStream ms = new MemoryStream();
                decryptFile(item.ToString());

                if (checkBoxKeep.CheckState == CheckState.Unchecked)
                {
                    try
                    {
                        File.Delete(item.ToString());
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            logEntry = String.Format("{0}  Finished decryption.", DateTime.Now.ToString());
            addLog(logEntry);
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private bool addFile(string file)
        {
            if (!encryptedFiles.Contains(file))
            {
                encryptedFiles.Add(file);
                listBoxEncFiles.Items.Add(file);
                return true;
            }

            return false;
        }

        private void addLog(string logEntry)
        {
            listBoxLogs.Items.Add(logEntry);
            listBoxLogs.SelectedIndex = listBoxLogs.Items.Count - 1;
            listBoxLogs.SelectedIndex = -1;
        }

        // Taken from https://stackoverflow.com/a/4986333
        internal static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                }
                catch { }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }
        
        private string GetCandidateFile()
        {
            string candidateName = "";

            foreach (var file in encryptedFiles)
            {
                string originalName = file.Remove(file.Length - 4, 4);
                if (originalName.EndsWith(".pdf"))
                {
                    candidateName = file;
                    break;
                }
            }

            return candidateName;
        }

        private void BruteForce(int currentIndex)
        {
            for(int i1=0; i1<alphabet.Length; i1++)
            {
                guess[0] = alphabet[i1];

                for (int i2 = 0; i2 < alphabet.Length; i2++)
                {
                    guess[1] = alphabet[i2];

                    for (int i3 = 0; i3 < alphabet.Length; i3++)
                    {
                        guess[2] = alphabet[i3];

                        for (int i4 = 0; i4 < alphabet.Length; i4++)
                        {
                            guess[3] = alphabet[i4];

                            for (int i5 = 0; i5 < alphabet.Length; i5++)
                            {
                                guess[4] = alphabet[i5];

                                for (int i6 = 0; i6 < alphabet.Length; i6++)
                                {
                                    guess[5] = alphabet[i6];

                                    for (int i7 = 0; i7 < alphabet.Length; i7++)
                                    {
                                        guess[6] = alphabet[i7];

                                        for (int i8 = 0; i8 < alphabet.Length; i8++)
                                        {
                                            guess[7] = alphabet[i8];

                                            counter++;

                                            if(counter == 1000000)
                                            {
                                                sw.Stop();
                                                addLog(sw.Elapsed.TotalSeconds.ToString());
                                                return;
                                            }

                                            byte[] key = new UnicodeEncoding().GetBytes(guess);
                                            byte[] iv = new UnicodeEncoding().GetBytes(guess);

                                            var rmCrypto = new RijndaelManaged();
                                            rmCrypto.Padding = PaddingMode.Zeros;
                                            var decryptor = rmCrypto.CreateDecryptor(key, iv);

                                            using (MemoryStream msCrypt = new MemoryStream(buffer))
                                            {
                                                CryptoStream cs = new CryptoStream(msCrypt, decryptor, CryptoStreamMode.Read);
                                                var decrypted = new MemoryStream();
                                                cs.CopyTo(decrypted);

                                                var decryptedArray = decrypted.ToArray();

                                                bool result = true;

                                                for (int j = 0; j < 4; j++)
                                                    if (decryptedArray[j] != pdfSignature[j])
                                                        result = false;

                                                if (result)
                                                {
                                                    password = new string(guess);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void decryptFile(string encryptedFile)
        {
            try
            {
                using (FileStream fsCrypt = File.OpenRead(encryptedFile))
                {
                    using (MemoryStream msCrypt = new MemoryStream())
                    {
                        fsCrypt.CopyTo(msCrypt);
                        string filenameWithoutEnc = Path.ChangeExtension(encryptedFile, null);
                        using (FileStream fsDecrypted = File.Create(filenameWithoutEnc))
                        {
                            msCrypt.Position = 0;
                            var msDecrypted = decryptStream(msCrypt, key, iv);
                            msDecrypted.Position = 0;
                            msDecrypted.CopyTo(fsDecrypted);

                            string logEntry = String.Format("{0}  Decrypted file: {1}", DateTime.Now.ToString(), filenameWithoutEnc);
                            addLog(logEntry);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static MemoryStream decryptStream(MemoryStream ms, byte[] key, byte[] iv)
        {
            MemoryStream decrypted = null;

            try
            {
                var rmCrypto = new RijndaelManaged();
                var decryptor = rmCrypto.CreateDecryptor(key, iv);
                CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                decrypted = new MemoryStream();
                cs.CopyTo(decrypted);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return decrypted;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            string message = "Decryptor for Crypren sample with SHA256: ce53233a435923a68a9ca6987f0d6333bb97d5a435b942d20944356ac29df598";

            MessageBox.Show(message, "About");
        }

        private void checkBoxKeep_CheckStateChanged(object sender, EventArgs e)
        {
            string logEntry;

            if (checkBoxKeep.CheckState == CheckState.Checked)
            {
                logEntry = String.Format("{0}  Encrypted files will be kept.", DateTime.Now.ToString());
            }
            else
            {
                logEntry = String.Format("{0}  Encrypted files will be deleted.", DateTime.Now.ToString());
            }

            addLog(logEntry);
        }
    }
}
