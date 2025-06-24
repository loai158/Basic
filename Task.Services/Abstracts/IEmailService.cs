using Microsoft.AspNetCore.Http;

namespace Task.Services.Abstracts
{
    public interface IEmailService
    {
        System.Threading.Tasks.Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
    }
}
