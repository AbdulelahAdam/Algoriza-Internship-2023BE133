using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Doctor
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName{ set; get; }
        public string EmailAddress { set; get; } 
        public string PhoneNumber { set; get; }
        public string Specialization { set; get; }
        public Gender? Gender{ set; get; }
        public string DateOfBirth { set; get; } 
        public string Image { set; get; } // Change to Image handler object

        public ICollection<Patient> Patients { get; set; }
    }

    public interface IDoctorService {
        Booking GetAllBookings(Doctor obj);
        bool ConfirmCheckUp(int BookingId);

        bool AddAppointment(Appointment obj);
        bool UpdateAppointment(Appointment obj);
        bool DeleteAppointment(Appointment obj);
    }
}