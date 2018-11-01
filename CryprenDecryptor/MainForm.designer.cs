namespace CryprenDecryptor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelEncFiles = new System.Windows.Forms.Label();
            this.listBoxEncFiles = new System.Windows.Forms.ListBox();
            this.labelLogs = new System.Windows.Forms.Label();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.checkBoxKeep = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // labelEncFiles
            // 
            this.labelEncFiles.AutoSize = true;
            this.labelEncFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEncFiles.Location = new System.Drawing.Point(13, 9);
            this.labelEncFiles.Name = "labelEncFiles";
            this.labelEncFiles.Size = new System.Drawing.Size(88, 13);
            this.labelEncFiles.TabIndex = 0;
            this.labelEncFiles.Text = "Encrypted Files:";
            // 
            // listBoxEncFiles
            // 
            this.listBoxEncFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEncFiles.FormattingEnabled = true;
            this.listBoxEncFiles.Location = new System.Drawing.Point(16, 25);
            this.listBoxEncFiles.Name = "listBoxEncFiles";
            this.listBoxEncFiles.Size = new System.Drawing.Size(468, 225);
            this.listBoxEncFiles.TabIndex = 1;
            // 
            // labelLogs
            // 
            this.labelLogs.AutoSize = true;
            this.labelLogs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogs.Location = new System.Drawing.Point(13, 269);
            this.labelLogs.Name = "labelLogs";
            this.labelLogs.Size = new System.Drawing.Size(35, 13);
            this.labelLogs.TabIndex = 2;
            this.labelLogs.Text = "Logs:";
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.Location = new System.Drawing.Point(16, 285);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(468, 56);
            this.listBoxLogs.TabIndex = 3;
            // 
            // buttonScan
            // 
            this.buttonScan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScan.Location = new System.Drawing.Point(490, 25);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(146, 52);
            this.buttonScan.TabIndex = 4;
            this.buttonScan.Text = "Scan All Drives";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.buttonScan_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddFile.Location = new System.Drawing.Point(566, 83);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(70, 52);
            this.buttonAddFile.TabIndex = 5;
            this.buttonAddFile.Text = "Add File";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.Location = new System.Drawing.Point(566, 285);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(70, 56);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDecrypt.Location = new System.Drawing.Point(490, 198);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(146, 52);
            this.buttonDecrypt.TabIndex = 7;
            this.buttonDecrypt.Text = "Start Decryption";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // checkBoxKeep
            // 
            this.checkBoxKeep.AutoSize = true;
            this.checkBoxKeep.Checked = true;
            this.checkBoxKeep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxKeep.Location = new System.Drawing.Point(490, 175);
            this.checkBoxKeep.Name = "checkBoxKeep";
            this.checkBoxKeep.Size = new System.Drawing.Size(131, 17);
            this.checkBoxKeep.TabIndex = 8;
            this.checkBoxKeep.Text = "Keep Encrypted Files";
            this.checkBoxKeep.UseVisualStyleBackColor = true;
            this.checkBoxKeep.CheckStateChanged += new System.EventHandler(this.checkBoxKeep_CheckStateChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.Location = new System.Drawing.Point(490, 285);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(70, 56);
            this.buttonAbout.TabIndex = 9;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddFolder.Location = new System.Drawing.Point(490, 83);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(70, 52);
            this.buttonAddFolder.TabIndex = 10;
            this.buttonAddFolder.Text = "Scan Folder";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.checkBoxKeep);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.buttonScan);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.labelLogs);
            this.Controls.Add(this.listBoxEncFiles);
            this.Controls.Add(this.labelEncFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crypren Decrypter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEncFiles;
        private System.Windows.Forms.ListBox listBoxEncFiles;
        private System.Windows.Forms.Label labelLogs;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.CheckBox checkBoxKeep;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

