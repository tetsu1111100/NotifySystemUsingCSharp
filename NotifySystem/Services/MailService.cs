using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NotifySystem.Services
{
    class MailService
    {
        private string _smtpHost = @"smtp.gmail.com"; // 替換為你的SMTP伺服器地址
        private int _smtpPort = 587;    // 替換為你的SMTP伺服器端口(587 (TLS) 或 465 (SSL))
        private string _smtpUsername = "your-smtp@gmail.com";    // 替換為你的SMTP伺服器帳號(gmail需要先至Google帳戶管理設定低安全性應用程式存取權)
        private string _smtpPassword = "your-password"; // 替換為你的SMTP伺服器密碼
        
        /// <summary>
        /// 發送Mail
        /// </summary>
        /// <param name="fromAddress">寄件者郵件地址</param>
        /// <param name="toAddress">收件者郵件地址</param>
        /// <param name="subject">郵件主旨</param>
        /// <param name="body"><郵件內容/param>
        public void SendMessage(string fromAddress, string toAddress, string subject, string body)
        {
            // 設定SMTP伺服器
            string smtpHost = _smtpHost; // 替換為你的SMTP伺服器地址
            int smtpPort = _smtpPort; // 替換為你的SMTP伺服器端口
            string smtpUsername = _smtpUsername; // 替換為你的SMTP伺服器帳號
            string smtpPassword = _smtpPassword; // 替換為你的SMTP伺服器密碼

            // 建立MailMessage物件
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromAddress);
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = body;

            // 設定SmtpClient物件
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true // 如果SMTP伺服器需要SSL，則設為true
            };

            try
            {
                // 發送郵件
                smtpClient.Send(mail);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // 捕獲並顯示異常
                Console.WriteLine("Failed to send email. Error: " + ex.Message);
            }
        }
    }
}
