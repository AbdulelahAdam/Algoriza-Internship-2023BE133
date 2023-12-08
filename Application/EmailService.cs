using Core.Interfaces;
using Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Application
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public Task SendEmailAsync(string to, string subject, string body)
        {
            return _emailRepository.SendEmailAsync(to, subject, body);
        }
    }
}
