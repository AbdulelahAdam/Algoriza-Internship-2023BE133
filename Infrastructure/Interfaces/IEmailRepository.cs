using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
