using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IPatientService
    {
        Task<bool> Register(Patient patient);
        IEnumerable<Booking> GetAllBookings();
    }
}
