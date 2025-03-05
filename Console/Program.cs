using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using OfficeOpenXml;
using Logsystem;

namespace EmailMarketingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogInfo("Starting Sending Emails From Excel File...");

            string excelFilePath = @"C:\Path\to\your\emails.xlsx";

            string smtpHost = "yoursmtp.example.com";
            int smtpPort = 587;
            string smtpUser = "yourUsername";
            string smtpPass = "YourPassword";

            string fromEmail = "YourEmailAddress@example.com";

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

                    string htmlBody = $@"
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

                        Console.WriteLine($"Email Be {toEmail} Ba Movafagiat Ersal Shod.");
                        Logger.LogSuccess($"Email Be {toEmail} Ba Movafagiat Ersal Shod.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Khata Dar Hengame Ersal Email Be  {toEmail}: {ex.Message}");
                        Logger.LogError($"Khata Dar Hengame Ersal Email Be  {toEmail}: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("Ersal Email Ha Be Payan Resid.");
            Logger.LogInfo("Ersal Email Ha Be Payan Resid.");

            Console.ReadLine();
        }
    }
}