using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IAdminService
    {
        // Dashboard Operations

        int NumberOfDoctors();
        int NumberOfPatients();
        int NumberOfRequests();


        int DoctorsRegisteredLast24Hours();
        int PatientsRegisteredLast24Hours();
        int RequestsMadeLast24Hours();



        // Operations on Doctors
        IEnumerable<Doctor> GetAllDoctors(int skip, int page, string search);
        Doctor GetDoctorById(int doctorId);
        Task<bool> AddDoctor(Doctor doctor);
        bool EditDoctor(Doctor doctor);
        bool DeleteDoctor(string id);

        // Operations on Patiens
        IEnumerable<Patient> GetAllPatients(int skip, int page, string search);
        Patient GetPatientById(int patientId);


        // Discount Coupon Settings

        bool AddCoupon(CouponPayload obj);
        bool UpdateCoupon(int id, CouponPayload changedCoupon);
        bool DeleteCoupon(int id);
        bool DeactivateCoupon(int id);

    }
}
