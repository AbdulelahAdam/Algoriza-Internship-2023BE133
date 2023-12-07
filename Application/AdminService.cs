using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int RequestsMadeLast24Hours()
        {
            return _adminRepository.RequestsMadeLast24Hours();
        }

        public bool UpdateCoupon(int id, CouponPayload changedCoupon)
        {
            return _adminRepository.UpdateCoupon(id, changedCoupon);
        }
    }
}
