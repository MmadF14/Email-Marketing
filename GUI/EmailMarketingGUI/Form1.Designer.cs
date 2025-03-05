namespace EmailMarketingGUI
{
    partial class Form1
    {

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnBrowse = new Button();
            btnSendEmails = new Button();
            txtExcelPath = new TextBox();
            txtSmtpHost = new TextBox();
            txtSmtpPort = new TextBox();
            txtSmtpUser = new TextBox();
            txtSmtpPass = new TextBox();
            txtFromEmail = new TextBox();
            txtLog = new TextBox();
            lblExcelPath = new Label();
            lblSmtpHost = new Label();
            lblSmtpPort = new Label();
            lblSmtpUser = new Label();
            lblSmtpPass = new Label();
            lblFromEmail = new Label();
            SuspendLayout();

            btnBrowse.Location = new Point(380, 25);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(80, 23);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;

            btnSendEmails.Location = new Point(20, 220);
            btnSendEmails.Name = "btnSendEmails";
            btnSendEmails.Size = new Size(90, 30);
            btnSendEmails.TabIndex = 1;
            btnSendEmails.Text = "Send Emails";
            btnSendEmails.UseVisualStyleBackColor = true;
            btnSendEmails.Click += btnSendEmails_Click;

            txtExcelPath.Location = new Point(100, 25);
            txtExcelPath.Name = "txtExcelPath";
            txtExcelPath.Size = new Size(270, 23);
            txtExcelPath.TabIndex = 2;

            txtSmtpHost.Location = new Point(100, 60);
            txtSmtpHost.Name = "txtSmtpHost";
            txtSmtpHost.Size = new Size(150, 23);
            txtSmtpHost.TabIndex = 3;

            txtSmtpPort.Location = new Point(325, 59);
            txtSmtpPort.Name = "txtSmtpPort";
            txtSmtpPort.Size = new Size(60, 23);
            txtSmtpPort.TabIndex = 4;

            txtSmtpUser.Location = new Point(100, 95);
            txtSmtpUser.Name = "txtSmtpUser";
            txtSmtpUser.Size = new Size(280, 23);
            txtSmtpUser.TabIndex = 5;
 
            txtSmtpPass.Location = new Point(100, 130);
            txtSmtpPass.Name = "txtSmtpPass";
            txtSmtpPass.PasswordChar = '*';
            txtSmtpPass.Size = new Size(280, 23);
            txtSmtpPass.TabIndex = 6;

            txtFromEmail.Location = new Point(100, 165);
            txtFromEmail.Name = "txtFromEmail";
            txtFromEmail.Size = new Size(280, 23);
            txtFromEmail.TabIndex = 7;

            txtLog.Location = new Point(20, 270);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(440, 120);
            txtLog.TabIndex = 8;

            lblExcelPath.AutoSize = true;
            lblExcelPath.Location = new Point(20, 28);
            lblExcelPath.Name = "lblExcelPath";
            lblExcelPath.Size = new Size(64, 15);
            lblExcelPath.TabIndex = 9;
            lblExcelPath.Text = "Excel Path:";

            lblSmtpHost.AutoSize = true;
            lblSmtpHost.Location = new Point(20, 63);
            lblSmtpHost.Name = "lblSmtpHost";
            lblSmtpHost.Size = new Size(68, 15);
            lblSmtpHost.TabIndex = 10;
            lblSmtpHost.Text = "SMTP Host:";

            lblSmtpPort.AutoSize = true;
            lblSmtpPort.Location = new Point(260, 63);
            lblSmtpPort.Name = "lblSmtpPort";
            lblSmtpPort.Size = new Size(65, 15);
            lblSmtpPort.TabIndex = 11;
            lblSmtpPort.Text = "SMTP Port:";

            lblSmtpUser.AutoSize = true;
            lblSmtpUser.Location = new Point(20, 98);
            lblSmtpUser.Name = "lblSmtpUser";
            lblSmtpUser.Size = new Size(66, 15);
            lblSmtpUser.TabIndex = 12;
            lblSmtpUser.Text = "SMTP User:";

            lblSmtpPass.AutoSize = true;
            lblSmtpPass.Location = new Point(20, 133);
            lblSmtpPass.Name = "lblSmtpPass";
            lblSmtpPass.Size = new Size(66, 15);
            lblSmtpPass.TabIndex = 13;
            lblSmtpPass.Text = "SMTP Pass:";

            lblFromEmail.AutoSize = true;
            lblFromEmail.Location = new Point(20, 168);
            lblFromEmail.Name = "lblFromEmail";
            lblFromEmail.Size = new Size(70, 15);
            lblFromEmail.TabIndex = 14;
            lblFromEmail.Text = "From Email:";

            ClientSize = new Size(484, 411);
            Controls.Add(lblFromEmail);
            Controls.Add(lblSmtpPass);
            Controls.Add(lblSmtpUser);
            Controls.Add(lblSmtpPort);
            Controls.Add(lblSmtpHost);
            Controls.Add(lblExcelPath);
            Controls.Add(txtLog);
            Controls.Add(txtFromEmail);
            Controls.Add(txtSmtpPass);
            Controls.Add(txtSmtpUser);
            Controls.Add(txtSmtpPort);
            Controls.Add(txtSmtpHost);
            Controls.Add(txtExcelPath);
            Controls.Add(btnSendEmails);
            Controls.Add(btnBrowse);
            Name = "Form1";
            Text = "Email Marketing App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSendEmails;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.TextBox txtSmtpPort;
        private System.Windows.Forms.TextBox txtSmtpUser;
        private System.Windows.Forms.TextBox txtSmtpPass;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblExcelPath;
        private System.Windows.Forms.Label lblSmtpHost;
        private System.Windows.Forms.Label lblSmtpPort;
        private System.Windows.Forms.Label lblSmtpUser;
        private System.Windows.Forms.Label lblSmtpPass;
        private System.Windows.Forms.Label lblFromEmail;
        private System.ComponentModel.IContainer components = null;
    }
}
