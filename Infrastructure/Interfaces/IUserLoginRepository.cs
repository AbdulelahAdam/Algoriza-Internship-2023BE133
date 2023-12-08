using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserLoginRepository
    {
        string Generate(ApplicationUser admin);
        ApplicationUser Authenticate(ApplicationUser admin);
    }
}
