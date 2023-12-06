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

        public bool AddAppointment(string doctorId, AppointmentPayload payload)
        {
            
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
                        TimeSlotId = _timeSlotService.GetTimeSlotIdForAppointmentTime(time),
                        Price = payload.Price
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



        public bool ConfirmCheckUp(int BookingId, string doctorId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == BookingId && b.DoctorId == doctorId);

            if(booking != null && booking.Status == BookingStatus.PENDING)
            {
                booking.Status = BookingStatus.COMPLETED;
                _context.SaveChanges();
                return true;
            }

            return false;

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

        public IEnumerable<Booking> GetAllBookings(string doctorId, int pageNumber, int pageSize, string search)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            int skip = (pageNumber - 1) * pageSize;


            var paginatedData =
                _context.Bookings.Where(b => b.DoctorId == doctorId)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }

        public bool UpdateAppointment(string doctorId, AppointmentPayload payload)
        {
            Days parsedDay;
            
            var doctor = _context.Doctors
                .Include(d => d.Appointments)
                .FirstOrDefault(d => d.Id == doctorId);

            if (doctor != null)
            {
                foreach (var (day, times) in payload.Appointments)
                {
                    parsedDay = _daysService.GetParsedDay(day);
                    foreach (var time in times)
                    {
                        var newAppointment = new Appointment
                        {
                            DoctorId = doctorId,
                            Day = parsedDay,
                            TimeSlotId = _timeSlotService.GetTimeSlotIdForAppointmentTime(time),
                            Price = payload.Price
                        };
                        var doctorAppointments = _context.Appointments.Update(newAppointment);
                        //doctorAppointments.State = Microsoft.EntityFrameworkCore.EntityState.Modified
                        _context.SaveChanges();

                    }

                }

            }
            return true;

        }
    }
}
