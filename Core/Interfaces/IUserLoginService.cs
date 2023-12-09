namespace Core.Models
{
    public interface IUserLoginService
    {
        string Generate(ApplicationUser user);
        ApplicationUser Authenticate(ApplicationUser user);
    }
}
