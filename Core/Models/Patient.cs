using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Patient
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string EmailAddress { set; get; }
        public string PhoneNumber { set; get; }
        public Gender? Gender { set; get; }
        public string DateOfBirth { set; get; }
        public string Image { set; get; } // Change to Image handler object


        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }

    public interface IPatientService {
        IEnumerable<Patient> GetAllPatients();
        IEnumerable<Booking> GetAllBookings();
        Patient GetPatientById(int patientId);
    }
}
