using System.Threading.Tasks;

namespace My3rdBlog.Services.Email
{
    public interface IEmailService
    {
        Task SendEmail(string email, string subject, string message);
    }
}
