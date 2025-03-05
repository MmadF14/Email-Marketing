using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using OfficeOpenXml;   
using Logsystem;     

namespace EmailMarketingGUI
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = ofd.FileName;
            }
        }

        private void btnSendEmails_Click(object sender, EventArgs e)
        {
            string excelFilePath = txtExcelPath.Text.Trim();
            string smtpHost = txtSmtpHost.Text.Trim();
            string portText = txtSmtpPort.Text.Trim();
            int smtpPort = 587; 
            int.TryParse(portText, out smtpPort);

            string smtpUser = txtSmtpUser.Text.Trim();
            string smtpPass = txtSmtpPass.Text.Trim();
            string fromEmail = txtFromEmail.Text.Trim();

            if (string.IsNullOrEmpty(excelFilePath) ||
                string.IsNullOrEmpty(smtpHost) ||
                string.IsNullOrEmpty(smtpUser) ||
                string.IsNullOrEmpty(smtpPass) ||
                string.IsNullOrEmpty(fromEmail))
            {
                AppendLog("لطفاً تمام فیلدها را پر کنید.\r\n");
                return;
            }

            Logger.LogInfo("شروع ارسال ایمیل‌ها (Windows Forms).");

            try
            {
                FileInfo fileInfo = new FileInfo(excelFilePath);
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string toEmail = worksheet.Cells[row, 1].Text.Trim();  
                        string subject = worksheet.Cells[row, 2].Text.Trim();   
                        string body = worksheet.Cells[row, 3].Text.Trim();     

                        string htmlBody = BuildHtmlBody(subject, body);

                        try
                        {
                            using (MailMessage mail = new MailMessage())
                            {
                                mail.From = new MailAddress(fromEmail);
                                mail.To.Add(toEmail);
                                mail.Subject = subject;
                                mail.Body = htmlBody;
                                mail.IsBodyHtml = true;

                                using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
                                {
                                    smtp.Credentials = new NetworkCredential(smtpUser, smtpPass);
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }
                            }

                            AppendLog($"ایمیل به {toEmail} با موفقیت ارسال شد.\r\n");
                            Logger.LogSuccess($"ایمیل به {toEmail} با موفقیت ارسال شد.");
                        }
                        catch (Exception exMail)
                        {
                            AppendLog($"خطا در ارسال ایمیل به {toEmail}: {exMail.Message}\r\n");
                            Logger.LogError($"خطا در ارسال ایمیل به {toEmail}: {exMail.Message}");
                        }
                    }
                }

                AppendLog("ارسال ایمیل‌ها به پایان رسید.\r\n");
                Logger.LogInfo("پایان ارسال ایمیل‌ها.");
            }
            catch (Exception ex)
            {
                AppendLog($"خطا در خواندن اکسل یا ارسال ایمیل: {ex.Message}\r\n");
                Logger.LogError($"خطا در خواندن اکسل یا ارسال ایمیل: {ex.Message}");
            }
        }

        private string BuildHtmlBody(string subject, string body)
        {
            return $@"
<html>
<head>
    <meta charset=""utf-8"">
    <style>
        body {{
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
            font-family: IranSans;
        }}
        .container {{
            width: 100%;
            max-width: 600px;
            background-color: #ffffff;
            margin: 30px auto;
            border-radius: 8px;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }}
        .header {{
            background-color: #f97316; 
            padding: 20px;
            text-align: center;
        }}
        .header h1 {{
            margin: 0;
            font-size: 24px;
            color: #ffffff;
        }}
        .title {{
            padding: 20px;
            text-align: center;
            border-bottom: 1px solid #eee;
        }}
        .title h2 {{
            margin: 0;
            font-size: 20px;
            color: #333333;
        }}
        .content {{
            padding: 20px;
            line-height: 1.6;
            color: #555555;
        }}
        .content p {{
            margin-bottom: 15px;
        }}
        .footer {{
            background-color: #f9fafb;
            padding: 15px;
            text-align: center;
            font-size: 12px;
            color: #999999;
        }}
        .footer a {{
            color: #999999;
            text-decoration: none;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <h1>Email From Me</h1>
        </div>

        <div class=""title"">
            <h2>{subject}</h2>
        </div>

        <div class=""content"">
            <p>
                {body}
            </p>
        </div>

        <div class=""footer"">
            <p>Send By <strong>C# SMTP</strong>MmadF14</p>
            <p><a href=""https://yourwebsite.com"">yourwebsite.com</a></p>
        </div>
    </div>
</body>
</html>
";
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText(message);
        }
    }
}
