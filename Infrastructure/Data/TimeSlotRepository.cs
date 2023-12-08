using Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Infrastructure.Data
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeSlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetTimeSlotIdForAppointmentTime(string appointmentTime)
        {
            TimeSpan appointmentTimeSpan = TimeSpan.Parse(appointmentTime);

            var timeSlot = _context.TimeSlots
                .FirstOrDefault(ts => ts.StartTime == appointmentTimeSpan);

            return timeSlot?.Id ?? 0;

        }
    }
}
