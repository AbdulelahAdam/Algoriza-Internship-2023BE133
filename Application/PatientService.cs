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
        private readonly IBookingRepository _bookingRepository;

        public PatientService(IPatientRepository patientRepository, IBookingRepository bookingRepository)
        {
            _patientRepository = patientRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> Register(Patient patient)
        {
            return await _patientRepository.Register(patient);

        }
        

        public IEnumerable<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllDoctors(int skip, int page)
        {
            return _patientRepository.GetAllDoctors(skip, page);
        }

        public bool MakeBooking(BookingPayload obj, string patientId)
        {
            return _bookingRepository.MakeBooking(obj, patientId);
        }
    }
}
