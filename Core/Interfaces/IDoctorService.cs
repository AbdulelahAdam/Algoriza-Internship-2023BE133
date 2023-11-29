using System.Collections.Generic;

namespace Core.Models
{
    public interface IDoctorService
    {
        IEnumerable<Booking> GetAllBookings(Doctor obj);
        bool ConfirmCheckUp(int BookingId);

        bool AddAppointment(Appointment obj);
        bool UpdateAppointment(Appointment obj);
        bool DeleteAppointment(Appointment obj);
    }
}