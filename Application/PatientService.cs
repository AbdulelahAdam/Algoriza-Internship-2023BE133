using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Interfaces;

namespace Application
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> Register(Patient patient)
        {
            return await _patientRepository.Register(patient);

        }
        

        public IEnumerable<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }
    }
}
