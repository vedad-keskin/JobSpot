using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace api.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string toEmail, string subject, StringBuilder body)
        {
            SmtpClient client = new(Environment.GetEnvironmentVariable("smtp_server"), 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("smtp_user"), Environment.GetEnvironmentVariable("smtp_pass"))
            };

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(Environment.GetEnvironmentVariable("smtp_user") ?? "");
            mailMessage.To.Add(toEmail);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
           
            mailMessage.Body = body.ToString();

            client.Send(mailMessage);
        }
    }
}

