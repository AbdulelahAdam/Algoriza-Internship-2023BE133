using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ITimeSlotService _timeSlotService;
        private readonly IDaysService _daysService;

        public DoctorRepository(ApplicationDbContext context, ITimeSlotService timeSlotService, IDaysService daysService)
        {
            _context = context;
            _timeSlotService = timeSlotService;
            _daysService = daysService;
        }

        public bool AddAppointment(AppointmentPayload payload)
        {
            var doctorId = payload.DoctorId;
            int appointmentsCount = 0;
            int dbSaves = 0;
            Days parsedDay;
            foreach (var (day, times) in payload.Appointments)
            {
                parsedDay = _daysService.GetParsedDay(day);
                foreach (var time in times)
                {
                    var appointment = new Appointment
                    {
                        DoctorId = doctorId,
                        Day = parsedDay,
                        TimeSlotId = _timeSlotService.GetTimeSlotIdForAppointmentTime(time)
                    };
                    ++appointmentsCount;
                    var doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctorId); // also this here doesn't eqaute, there's an error

                    if (doctor != null)
                    {
                        doctor.Appointments.Add(appointment);
                        dbSaves += _context.SaveChanges();
                    }
                }

            }
            return (dbSaves == appointmentsCount);
        }



        public bool ConfirmCheckUp(int BookingId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAppointment(int doctorId)
        {
            string Id = Convert.ToString(doctorId);

            var doctor = _context.Doctors
                .Include(d => d.Appointments)
                .FirstOrDefault(d => d.Id == Id);

            if (doctor != null)
            {
                doctor.Appointments.Clear();
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Booking> GetAllBookings(Doctor obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAppointment(AppointmentPayload payload)
        {
            var doctorId = payload.DoctorId;
            Days parsedDay;

            
            var doctor = _context.Doctors
                .Include(d => d.Appointments)
                .FirstOrDefault(d => d.Id == doctorId);

            if (doctor != null)
            {
                doctor.Appointments.Clear();
                foreach (var (day, times) in payload.Appointments)
                {
                    parsedDay = _daysService.GetParsedDay(day);
                    foreach (var time in times)
                    {
                        var newAppointment = new Appointment
                        {
                            DoctorId = doctorId,
                            Day = parsedDay,
                            TimeSlotId = _timeSlotService.GetTimeSlotIdForAppointmentTime(time)
                        };
                        var doctorAppointments = _context.Appointments.Add(newAppointment);
                        _context.SaveChanges();

                    }

                }

            }
            return true;

        }
    }
}
