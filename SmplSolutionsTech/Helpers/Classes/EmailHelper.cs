using SendGrid;
using SendGrid.Helpers.Mail;

namespace SmplSolutionsTech.Helpers.Classes
{
    public class EmailHelper : IEmailHelper
    {
        private readonly Config _config;

        //private readonly MailAddress _from;
        //private readonly NetworkCredential _netCred;
        //private readonly string _host;
        //private readonly int _port;
        private readonly ILogger<EmailHelper> _logger;

        public EmailHelper(Config config, ILogger<EmailHelper> logger)
        {
            _config = config;
            //_from = new MailAddress(config.EmailSettings.User, "Prodigal Techie");
            //_netCred = new NetworkCredential(config.EmailSettings.User, config.EmailSettings.Password);
            //_host = config.EmailSettings.Host;
            //_port = config.EmailSettings.Port;
            _logger = logger;
        }

        public async Task<bool> SendHtmlMessageWithoutReplyToAsync(string recipient, string subject, string body, bool htmlContent = true)
        {
            if (string.IsNullOrEmpty(_config.SendGridKey)) throw new Exception("Null SendGridKey");
            return await SendMessageAsync(new List<EmailAddress> { new EmailAddress { Email = recipient } } , null, subject, body, htmlContent, _config.SendGridKey);
        }


        // Allows us to send emails to multiple recipients and multiple reply to addresses. With or without html content (default is without).
        public async Task<bool> SendMessageAsync(List<EmailAddress> recipients, List<EmailAddress> replyToList, string subject, string body, bool htmlContent = false, string apiKey = null)
        {
            try
            {
                
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("kbuss@smplsolutionstech.com", "Prodigal Techie"),
                    Subject = subject,
                    PlainTextContent = body,
                    HtmlContent = body
                };
                msg.AddTos(recipients);

                // Disable click tracking.
                // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
                msg.SetClickTracking(false, false);
                var response = await client.SendEmailAsync(msg);
                return response.IsSuccessStatusCode;
                //var client = new SmtpClient
                //{
                //    Host = _host,
                //    Port = _port,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    UseDefaultCredentials = true,
                //    Credentials = _netCred
                //};
                //var message = new MailMessage
                //{
                //    From = _from,
                //    Subject = subject,
                //    Body = body,
                //    IsBodyHtml = htmlContent
                //};
                //if (attachments != null)
                //{
                //    foreach (var attachment in attachments)
                //    {
                //        message.Attachments.Add(attachment); // add attachments if exist
                //    }
                //}
                //message.To.AddRange(recipients.Select(x => new MailAddress(x)));
                //if (replyToList != null)
                //    message.ReplyToList.AddRange(replyToList.Select(x => new MailAddress(x)));

                //client.Send(message);
                //client.Dispose();
                //message.Dispose();
                //return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "");
                return false;
            }
        }
    }
}
