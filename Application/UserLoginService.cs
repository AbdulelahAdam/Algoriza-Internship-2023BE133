using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _userLoginRepository;

        public UserLoginService(IUserLoginRepository userLoginRepository)
        {
            _userLoginRepository = userLoginRepository;
        }

        public ApplicationUser Authenticate(ApplicationUser admin)
        {
            return _userLoginRepository.Authenticate(admin);
        }

        public string Generate(ApplicationUser admin)
        {
            return _userLoginRepository.Generate(admin);
        }
    }
}
