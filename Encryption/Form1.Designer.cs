
namespace Encryption
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPath = new System.Windows.Forms.Label();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.rbEncrypt = new System.Windows.Forms.RadioButton();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 43);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(55, 15);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "File path:";
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(12, 61);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(267, 23);
            this.tbxPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(285, 61);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(12, 125);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(348, 23);
            this.btnExec.TabIndex = 3;
            this.btnExec.Text = "Start";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(12, 9);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(60, 15);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Password:";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(78, 6);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(201, 23);
            this.tbxPassword.TabIndex = 5;
            // 
            // rbEncrypt
            // 
            this.rbEncrypt.AutoSize = true;
            this.rbEncrypt.Location = new System.Drawing.Point(12, 100);
            this.rbEncrypt.Name = "rbEncrypt";
            this.rbEncrypt.Size = new System.Drawing.Size(65, 19);
            this.rbEncrypt.TabIndex = 6;
            this.rbEncrypt.TabStop = true;
            this.rbEncrypt.Text = "Encrypt";
            this.rbEncrypt.UseVisualStyleBackColor = true;
            this.rbEncrypt.CheckedChanged += new System.EventHandler(this.rbEncrypt_CheckedChanged);
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.AutoSize = true;
            this.rbDecrypt.Location = new System.Drawing.Point(112, 100);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(66, 19);
            this.rbDecrypt.TabIndex = 7;
            this.rbDecrypt.TabStop = true;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.UseVisualStyleBackColor = true;
            this.rbDecrypt.CheckedChanged += new System.EventHandler(this.rbDecrypt_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 172);
            this.Controls.Add(this.rbDecrypt);
            this.Controls.Add(this.rbEncrypt);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.lblPath);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.RadioButton rbEncrypt;
        private System.Windows.Forms.RadioButton rbDecrypt;
    }
}

