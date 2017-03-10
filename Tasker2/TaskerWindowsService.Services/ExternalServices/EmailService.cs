using System.Configuration;
using System.Net.Mail;
using System.Text;

namespace TaskerWindowsService.Services.ExternalServices
{
    public class EmailService : IEmailService
    {

        public EmailService()
        {
        }

        public bool Send(string email, bool isHtml, string subj, string text)
        {
            var message = new MailMessage
            {
                IsBodyHtml = isHtml,
                BodyEncoding = Encoding.UTF8,
                SubjectEncoding = Encoding.UTF8,
                Body = text,
                Subject = subj,
                From = new MailAddress(ConfigurationManager.AppSettings["EmailSender"], ConfigurationManager.AppSettings["EmailSenderName"]),
            };
            message.To.Add(email);
            SendMessage(message);
            message.Dispose();

            return true;
        }

        private void SendMessage(MailMessage message)
        {
            using (var client = CreateClient())
            {
                client.Send(message);
            }
            
        }

        private SmtpClient CreateClient()
        {
            int port;
            int.TryParse(ConfigurationManager.AppSettings["EmailSmtpPort"], out port);
            return new SmtpClient(ConfigurationManager.AppSettings["EmailSmtpServer"], port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailUserName"], ConfigurationManager.AppSettings["EmailPassword"])
            };
        }
    }
}