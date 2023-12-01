using System.Collections.Generic;

namespace Core.Models
{
    public interface IDoctorService
    {
        IEnumerable<Booking> GetAllBookings(Doctor obj);
        bool ConfirmCheckUp(int BookingId);

        bool AddAppointment(AppointmentPayload obj);
        bool UpdateAppointment(AppointmentPayload obj);
        bool DeleteAppointment(int doctorId);
    }
}