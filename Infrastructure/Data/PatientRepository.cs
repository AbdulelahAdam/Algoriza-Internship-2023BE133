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

        public IEnumerable<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllDoctors(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10; 
            }

            int skip = (pageNumber - 1) * pageSize;

            var paginatedData = _context.Doctors.Include(d => d.Appointments)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }

        public bool MakeBooking(string patientId, string doctorId, int timeSlotId)
        {
            return _bookingRepository.MakeBooking(patientId, doctorId, timeSlotId);
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
