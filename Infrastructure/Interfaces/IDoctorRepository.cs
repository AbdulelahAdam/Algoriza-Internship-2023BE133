﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDoctorRepository
    {
        IEnumerable<Booking> GetAllBookings(string doctorId, int pageNumber, int pageSize, string search);
        bool ConfirmCheckUp(int BookingId);

        bool AddAppointment(string doctorId, AppointmentPayload obj);
        bool UpdateAppointment(string doctorId, AppointmentPayload obj);
        bool DeleteAppointment(int doctorId);
    }
}
