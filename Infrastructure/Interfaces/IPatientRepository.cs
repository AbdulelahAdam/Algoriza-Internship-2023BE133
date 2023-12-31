﻿using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IPatientRepository
    {
        Task<bool> Register(Patient patient);
        IEnumerable<Booking> GetAllBookings(string patientId);
        IEnumerable<Doctor> GetAllDoctors(int skip, int page, string search);  
    }
}
