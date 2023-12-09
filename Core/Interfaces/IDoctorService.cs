using System;
using System.Collections.Generic;

namespace Core.Models
{
    public interface IDoctorService
    {
        IEnumerable<Booking> GetAllBookings(string doctorId, int pageNumber, int pageSize, DateTime search);
        bool ConfirmCheckUp(int BookingId, string doctorId);

        bool AddAppointment(string doctorId, AppointmentPayload obj);
        bool UpdateAppointment(string doctorId, AppointmentPayload obj);
        bool DeleteAppointment(string doctorId, AppointmentPayload obj);
    }
}