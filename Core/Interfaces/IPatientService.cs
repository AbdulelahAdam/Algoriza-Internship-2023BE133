using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IPatientService
    {
        Task<bool> Register(Patient patient);

        IEnumerable<Booking> GetAllBookings(string patientId);

        IEnumerable<Doctor> GetAllDoctors(int skip, int page, string search);
    }
}
