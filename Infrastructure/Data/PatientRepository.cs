using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IBookingRepository _bookingRepository;

        public PatientRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IBookingRepository bookingRepository)
        {
            _context = context;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        public IEnumerable<Booking> GetAllBookings(string patientId)
        {
            var patientBookings = _context.Bookings.Where(p => p.PatientId == patientId);

            return patientBookings;
        }

        public IEnumerable<Doctor> GetAllDoctors(int pageNumber, int pageSize, string search)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            int skip = (pageNumber - 1) * pageSize;

            var paginatedData = _context.Doctors.Include(d => d.Appointments).Where(d =>
                    d.UserName.Contains(search) ||
                    d.Email.Contains(search) ||
                    d.Id.Contains(search)
                )
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }


        public async Task<bool> Register(Patient patient)
        {
            var hashedPass = new PasswordHasher<Patient>().HashPassword(patient, patient.PasswordHash);
            patient.PasswordHash = hashedPass;
            var result = await _userManager.CreateAsync(patient);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

    }
}
