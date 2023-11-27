using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Application
{
    public class PatientService : IPatientService
    {
        public static bool Register(Patient patient)
        {
            return false;

        }
        
        public static bool Login(string Email, string Password)
        {
            return false;

        }
        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int patientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }
    }
}
