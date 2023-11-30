using Core.Models;
using Infrastructure.Interfaces;
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

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddAppointment(AppointmentPayload payload)
        {
            var doctorId = payload.DoctorId;
            int finalCount = 0;
            int dbSaves = 0;
            foreach (var (day, times) in payload.Appointments)
            {
                Enum.TryParse(day, out Days parsedDay);
                foreach (var time in times)
                {
                    var appointment = new Appointment
                    {
                        DoctorId = doctorId,
                        Day = parsedDay,
                        TimeSlotId = 32 // need to know how to parse days correctly
                    };
                    ++finalCount;
                    var doctor = _context.Doctors.FirstOrDefault(d => d.Id == "2"); // also this here doesn't eqaute, there's an error

                    if (doctor != null)
                    {
                        doctor.Appointments.Add(appointment);
                        dbSaves += _context.SaveChanges();                        
                    }
                }
                  
            }
            return (dbSaves == finalCount);
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
