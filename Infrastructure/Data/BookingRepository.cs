using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool MakeBooking(string patientId, string doctorId, int timeSlotId)
        {
            var booking = new Booking
            {
                PatientId = patientId,
                DoctorId = doctorId,
                TimeSlotId = timeSlotId,
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return true;
        }
    }
}
