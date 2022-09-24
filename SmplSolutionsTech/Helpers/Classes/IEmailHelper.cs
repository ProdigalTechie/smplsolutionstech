using System.Net.Mail;

namespace SmplSolutionsTech.Helpers.Classes
{
    public interface IEmailHelper
    {
        Task<bool> SendMessageAsync(List<string> recipients, List<string> replyToList, string subject, string body, bool htmlContent = false, List<Attachment> attachments = null);
        Task<bool> SendMessageWithoutReplyToAsync(string recipient, string subject, string body, bool htmlContent = false, List<Attachment> attachments = null);
    }
}
