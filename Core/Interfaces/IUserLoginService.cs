namespace Core.Models
{
    public interface IUserLoginService
    {
        string Generate(ApplicationUser admin);
        ApplicationUser Authenticate(ApplicationUser admin);
    }
}
