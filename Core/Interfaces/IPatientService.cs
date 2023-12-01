using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IPatientService
    {
        Task<bool> Register(Patient patient);
        bool MakeBooking(string patientId, string doctorId, int timeSlotId);

        IEnumerable<Booking> GetAllBookings();

        IEnumerable<Doctor> GetAllDoctors(int skip, int page);
    }
}
