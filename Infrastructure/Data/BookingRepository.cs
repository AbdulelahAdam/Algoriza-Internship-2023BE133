using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace Infrastructure.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context, IUserLoginService userLoginService)
        {
            _context = context;
        }

        public bool MakeBooking(BookingPayload obj, string patientId)
        {
            var appointmentInfo = _context.Appointments
            .Where(appointment => appointment.TimeSlotId == obj.TimeSlotId)
            .Select(appointment => new { appointment.DoctorId})
            .FirstOrDefault();

            var booking = new Booking
            {
                DoctorId = appointmentInfo.DoctorId,
                TimeSlotId = obj.TimeSlotId,
                PatientId = patientId
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return true;
        }
    }
}
