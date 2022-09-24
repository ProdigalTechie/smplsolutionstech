using System.Net.Mail;
using System.Net;
using NuGet.Packaging;

namespace SmplSolutionsTech.Helpers.Classes
{
    public class EmailHelper : IEmailHelper
    {
        private static readonly string _devEmail = "kbuss@smplsolutionstech.com";

        private readonly MailAddress _from;
        private readonly NetworkCredential _netCred;
        private readonly string _host;
        private readonly int _port;
        private readonly ILogger<EmailHelper> _logger;

        public EmailHelper(Config config, ILogger<EmailHelper> logger)
        {
            _from = new MailAddress(config.EmailSettings.User, "Prodigal Techie");
            _netCred = new NetworkCredential(config.EmailSettings.User, config.EmailSettings.Password);
            _host = config.EmailSettings.Host;
            _port = config.EmailSettings.Port;
            _logger = logger;
        }

        public async Task<bool> SendHtmlMessageWithoutReplyToAsync(string recipient, string subject, string body, bool htmlContent = true, List<Attachment> attachments = null)
        {
            return await SendMessageAsync(new List<string> { recipient }, null, subject, body, htmlContent, attachments);
        }


        // Allows us to send emails to multiple recipients and multiple reply to addresses. With or without html content (default is without).
        public async Task<bool> SendMessageAsync(List<string> recipients, List<string> replyToList, string subject, string body, bool htmlContent = false, List<Attachment> attachments = null)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var client = new SmtpClient
                    {
                        Host = _host,
                        Port = _port,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = true,
                        Credentials = _netCred
                    };
                    var message = new MailMessage
                    {
                        From = _from,
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = htmlContent
                    };
                    if (attachments != null)
                    {
                        foreach (var attachment in attachments)
                        {
                            message.Attachments.Add(attachment); // add attachments if exist
                        }
                    }
                    message.To.AddRange(recipients.Select(x => new MailAddress(x)));
                    if (replyToList != null)
                        message.ReplyToList.AddRange(replyToList.Select(x => new MailAddress(x)));

                    client.Send(message);
                    client.Dispose();
                    message.Dispose();
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "");
                    return false;
                }
            });
        }
    }
}
