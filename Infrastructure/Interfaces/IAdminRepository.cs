using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAdminRepository
    {
        // Dashboard Operations
        int NumberOfDoctors();
        int NumberOfPatients();
        int NumberOfRequests();
        Dictionary<string, int> GetDepartmentRankings();
        List<string> GetTopBookedDoctors();

        // Bonus Dashboard Operations
        int DoctorsRegisteredLast24Hours();
        int PatientsRegisteredLast24Hours();
        int RequestsMadeLast24Hours();


        int DoctorsRegisteredLastWeek();
        int PatientsRegisteredLastWeek();
        int RequestsMadeLastWeek();

        int DoctorsRegisteredLastMonth();
        int PatientsRegisteredLastMonth();
        int RequestsMadeLastMonth();

        int DoctorsRegisteredLastYear();
        int PatientsRegisteredLastYear();
        int RequestsMadeLastYear();


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
