using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAdminRepository
    {
        // Operations on Doctors
        IEnumerable<Doctor> GetAllDoctors(int skip, int page);
        IEnumerable<Doctor> GetAllDoctorsBySearch(string search);

        Doctor GetDoctorById(int doctorId);
        Task<bool> AddDoctor(Doctor doctor);
        bool EditDoctor(Doctor doctor);
        bool DeleteDoctor(int id);


        // Operations on Patiens
        IEnumerable<Patient> GetAllPatients(int skip, int page);
        Patient GetPatientById(int patientId);


        // Discount Coupon Settings

        bool AddCoupon(Coupon coupon);
        bool UpdateCoupon(Coupon changedCoupon);
        bool DeleteCoupon(int id);
        bool DeactivateCoupon(int id);
    }
}
