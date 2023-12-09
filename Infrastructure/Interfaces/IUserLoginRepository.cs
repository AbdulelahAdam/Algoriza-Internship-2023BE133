using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserLoginRepository
    {
        string Generate(ApplicationUser user);
        ApplicationUser Authenticate(ApplicationUser user);
    }
}
