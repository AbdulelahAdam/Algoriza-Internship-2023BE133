using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserLoginRepository
    {
        string Generate(ApplicationUser admin);
        ApplicationUser Authenticate(ApplicationUser admin);
    }
}
