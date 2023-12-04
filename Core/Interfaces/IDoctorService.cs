using System.Collections.Generic;

namespace Core.Models
{
    public interface IDoctorService
    {
        IEnumerable<Booking> GetAllBookings(string doctorId, int pageNumber, int pageSize, string search);
        bool ConfirmCheckUp(int BookingId);

        bool AddAppointment(string doctorId, AppointmentPayload obj);
        bool UpdateAppointment(string doctorId, AppointmentPayload obj);
        bool DeleteAppointment(int doctorId);
    }
}