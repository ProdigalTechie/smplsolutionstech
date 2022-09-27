using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace SmplSolutionsTech.Helpers.Classes
{
    public interface IEmailHelper
    {
        Task<bool> SendMessageAsync(List<EmailAddress> recipients, List<EmailAddress> replyToList, string subject, string body, bool htmlContent = false, string apiKey = null);
        Task<bool> SendHtmlMessageWithoutReplyToAsync(string recipient, string subject, string body, bool htmlContent = true);
    }
}
