using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
            int timeSlotId;
            foreach (var (day, times) in payload.Appointments)
            {
                parsedDay = _daysService.GetParsedDay(day);
                foreach (var time in times)
                {
                    timeSlotId = _timeSlotService.GetTimeSlotIdForAppointmentTime(time);// get parsed time

                    var appointment = new Appointment
                    {
                        DoctorId = doctorId,
                        Day = parsedDay,
                        TimeSlotId = timeSlotId,
                        Price = payload.Price
                    };
                    ++appointmentsCount;
                    var doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctorId);
                    var doctorAppointments = _context.Appointments.Where(a => a.DoctorId == doctor.Id && a.Day == parsedDay && a.TimeSlotId == timeSlotId).FirstOrDefault();

                    if (doctor != null && doctorAppointments == null) // If doctor exists and doesn't have an appointment on this specific day and time already?
                    {
                        doctor.Appointments.Add(appointment);
                        dbSaves += _context.SaveChanges();
                    }
                    else
                    {
                        return false; // Can't make an appointment that's already made
                    }
                }

            }
            return (dbSaves == appointmentsCount); // Added Appointment
        }



        public bool ConfirmCheckUp(int BookingId, string doctorId)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.Id == BookingId && b.DoctorId == doctorId);

            if (booking != null && booking.Status == BookingStatus.PENDING)
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

        public IEnumerable<Booking> GetAllBookings(string doctorId, int pageNumber, int pageSize, DateTime search)
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
                _context.Bookings.Where(b => b.DoctorId == doctorId && b.Status == BookingStatus.PENDING)
                .Where(b => b.BookingDate == search)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }

        public bool UpdateAppointment(string doctorId, AppointmentPayload payload)
        {
            Days parsedDay;
            int timeSlotId;

            foreach (var (day, times) in payload.Appointments)
            {
                parsedDay = _daysService.GetParsedDay(day);
                foreach (var time in times)
                {
                    timeSlotId = _timeSlotService.GetTimeSlotIdForAppointmentTime(time);// get parsed time

                    var doctorAppointment = _context.Appointments.Where(a => a.DoctorId == doctorId && a.Day == parsedDay && a.Price == payload.Price).FirstOrDefault();
                    var doctorBooking = _context.Bookings.Where(b => b.DoctorId == doctorId && b.TimeSlotId == timeSlotId);

                    if (doctorAppointment != null && doctorBooking == null) // appointment exists and not booked by patient
                    {
                        doctorAppointment.TimeSlotId = timeSlotId;

                        var result = _context.Appointments.Attach(doctorAppointment);
                        result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _context.SaveChanges();
                    }
                    else
                    {
                        return false; // Either this appointment doesn't exist, hence cannot update,
                                      // or this appointment is booked by a patient
                    }

                }

            }
            return true;

        }
    }
}
