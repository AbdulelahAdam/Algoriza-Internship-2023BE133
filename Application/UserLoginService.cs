using Core.Models;
using Infrastructure.Interfaces;


namespace Application
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public ApplicationUser Authenticate(ApplicationUser user)
        {
            return _userLoginRepository.Authenticate(user);
        }

        public string Generate(ApplicationUser user)
        {
            return _userLoginRepository.Generate(user);
        }
    }
}
