using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IPatientService
    {
        Task<bool> Register(Patient patient);
        bool MakeBooking(BookingPayload obj, string patientId);

        IEnumerable<Booking> GetAllBookings();

        IEnumerable<Doctor> GetAllDoctors(int skip, int page);
    }
}
