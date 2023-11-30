using Core.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public bool AddAppointment(AppointmentPayload obj)
        {
            return _doctorRepository.AddAppointment(obj);
        }

        public bool ConfirmCheckUp(int BookingId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAppointment(AppointmentPayload obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAllBookings(Doctor obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAppointment(AppointmentPayload obj)
        {
            throw new NotImplementedException();
        }
    }
}
