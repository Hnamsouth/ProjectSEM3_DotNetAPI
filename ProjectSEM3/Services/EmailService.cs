using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ProjectSEM3.Configuration;
using ProjectSEM3.DTOs.Auth;

namespace ProjectSEM3.Services
{
    public class EmailService : IEmailService
    {

        EmailSetting _emailsetting = null;
        private readonly string verifi_href = "http://localhost:3000/verify-email";
        public EmailService(IOptions<EmailSetting> options)
        {
            _emailsetting = options.Value;
        }

        public bool SendEmail(string name, string email,string token)
        {
            try
            {
                MimeMessage emailMess = new MimeMessage();

                emailMess.From.Add(new MailboxAddress(_emailsetting.Name, _emailsetting.EmailId));

                emailMess.To.Add(new MailboxAddress(name, email));

                emailMess.Subject = "Welcome to Adidos";

                string filepath = Directory.GetCurrentDirectory() + "\\Templates\\VerificationEmail.html";
                string emailTemplateText= File.ReadAllText(filepath);

                string href = verifi_href + "?token=" + token + "&email=" + email;

                emailTemplateText = string.Format(emailTemplateText, name, href);

                BodyBuilder emailbodyBuilder = new BodyBuilder();
                emailbodyBuilder.HtmlBody = emailTemplateText;
                emailMess.Body = emailbodyBuilder.ToMessageBody();

                SmtpClient emailClient = new SmtpClient();
                emailClient.Connect(_emailsetting.Host, _emailsetting.Port,SecureSocketOptions.StartTls);
                emailClient.Authenticate(_emailsetting.EmailId, _emailsetting.Password);
                emailClient.Send(emailMess);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
