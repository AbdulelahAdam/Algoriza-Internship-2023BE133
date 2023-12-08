using Infrastructure.Interfaces;
using MailKit.Security;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EmailRepository : IEmailRepository
    {
        public Task SendEmailAsync(string to, string subject, string body)
        {
            var mail = "internshipMailer@google.com";
            var pass = "helloWorld12300";

            var client = new SmtpClient("smtp-mail.outlook.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pass)
                
            };

            return client.SendMailAsync(
                    new MailMessage(from: mail,
                    to: to,
                    subject: subject,
                    body));
        }
    }
}
