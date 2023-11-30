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
        IEnumerable<Booking> GetAllBookings(Doctor obj);
        bool ConfirmCheckUp(int BookingId);

        bool AddAppointment(AppointmentPayload obj);
        bool UpdateAppointment(AppointmentPayload obj);
        bool DeleteAppointment(AppointmentPayload obj);
    }
}