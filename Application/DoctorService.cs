using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace Application
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public bool AddAppointment(string doctorId, AppointmentPayload obj)
        {
            return _doctorRepository.AddAppointment(doctorId, obj);
        }

        public bool ConfirmCheckUp(int BookingId, string doctorId)
        {
            return _doctorRepository.ConfirmCheckUp(BookingId, doctorId);
        }

        public bool DeleteAppointment(string doctorId, AppointmentPayload payload)
        {
            return _doctorRepository.DeleteAppointment(doctorId, payload);
        }

        public IEnumerable<Booking> GetAllBookings(string doctorId, int pageNumber, int pageSize, DateTime search)
        {
            return _doctorRepository.GetAllBookings(doctorId, pageNumber, pageSize, search);
        }

        public bool UpdateAppointment(string doctorId, AppointmentPayload obj)
        {
            return _doctorRepository.UpdateAppointment(doctorId, obj);
        }
    }
}
