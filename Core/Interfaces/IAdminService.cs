using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IAdminService
    {
        // Operations on Doctors
        IEnumerable<Doctor> GetAllDoctors(int skip, int page);
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
