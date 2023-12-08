using Core.Models;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public bool AddCoupon(CouponPayload obj)
        {
            return _adminRepository.AddCoupon(obj);
        }

        public Task<bool> AddDoctor(Doctor doctor)
        {
            return _adminRepository.AddDoctor(doctor);

        }


        public bool DeactivateCoupon(int id)
        {
            return _adminRepository.DeactivateCoupon(id);
        }

        public bool DeleteCoupon(int id)
        {
            return _adminRepository.DeleteCoupon(id);
        }

        public bool DeleteDoctor(string id)
        {
            return _adminRepository.DeleteDoctor(id);
        }

        public int DoctorsRegisteredLast24Hours()
        {
            return _adminRepository.DoctorsRegisteredLast24Hours();
        }

        public int DoctorsRegisteredLastMonth()
        {
            return _adminRepository.DoctorsRegisteredLastMonth();
        }

        public int DoctorsRegisteredLastWeek()
        {
            return _adminRepository.DoctorsRegisteredLastWeek();
        }

        public int DoctorsRegisteredLastYear()
        {
            return _adminRepository.DoctorsRegisteredLastYear();
        }

        public bool EditDoctor(Doctor doctor)
        {
            return _adminRepository.EditDoctor(doctor);
        }

        public IEnumerable<Doctor> GetAllDoctors(int skip, int page, string search)
        {
            return _adminRepository.GetAllDoctors(skip, page, search);
        }
        public IEnumerable<Patient> GetAllPatients(int skip, int page, string search)
        {
            return _adminRepository.GetAllPatients(skip, page, search);
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _adminRepository.GetDoctorById(doctorId);
        }

        public Patient GetPatientById(int patientId)
        {
            return _adminRepository.GetPatientById(patientId);

        }

        public int NumberOfDoctors()
        {
            return _adminRepository.NumberOfDoctors();
        }

        public int NumberOfPatients()
        {
            return _adminRepository.NumberOfPatients();
        }

        public int NumberOfRequests()
        {
            return _adminRepository.NumberOfRequests();
        }

        public int PatientsRegisteredLast24Hours()
        {
            return _adminRepository.PatientsRegisteredLast24Hours();
        }

        public int PatientsRegisteredLastMonth()
        {
            return _adminRepository.PatientsRegisteredLastMonth();
        }

        public int PatientsRegisteredLastWeek()
        {
            return _adminRepository.PatientsRegisteredLastWeek();
        }

        public int PatientsRegisteredLastYear()
        {
            return _adminRepository.PatientsRegisteredLastYear();
        }

        public int RequestsMadeLast24Hours()
        {
            return _adminRepository.RequestsMadeLast24Hours();
        }

        public int RequestsMadeLastYear()
        {
            return _adminRepository.RequestsMadeLastYear();
        }

        public int RequestsMadeLastMonth()
        {
            return _adminRepository.RequestsMadeLastMonth();
        }

        public int RequestsMadeLastWeek()
        {
            return _adminRepository.RequestsMadeLastWeek();
        }

        public bool UpdateCoupon(int id, CouponPayload changedCoupon)
        {
            return _adminRepository.UpdateCoupon(id, changedCoupon);
        }

        public Dictionary<string, int> GetDepartmentRankings()
        {
            return _adminRepository.GetDepartmentRankings();
        }

        public List<string> GetTopBookedDoctors()
        {
            return _adminRepository.GetTopBookedDoctors();
        }
    }
}
