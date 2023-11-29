using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PatientRepository : IPatientRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Register(Patient patient)
        {
            var result = await _userManager.CreateAsync(patient);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
