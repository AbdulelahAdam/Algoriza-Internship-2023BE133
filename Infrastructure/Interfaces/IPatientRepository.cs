using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IPatientRepository
    {
        Task<bool> Register(Patient patient);
        IEnumerable<Booking> GetAllBookings();
        bool MakeBooking(BookingPayload obj, string patientId);
        IEnumerable<Doctor> GetAllDoctors(int skip, int page);
    }
}
