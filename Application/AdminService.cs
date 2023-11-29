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

        public bool AddCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddDoctor(Doctor doctor)
        {
            return _adminRepository.AddDoctor(doctor);

        }

        public bool DeactivateCoupon(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCoupon(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDoctor(int id)
        {
            return _adminRepository.DeleteDoctor(id);
        }

        public bool EditDoctor(Doctor doctor)
        {
            return _adminRepository.EditDoctor(doctor);
        }

        public IEnumerable<Doctor> GetAllDoctors(int skip, int page)
        {
            return _adminRepository.GetAllDoctors(skip, page);
        }

        public IEnumerable<Patient> GetAllPatients(int skip, int page)
        {
            return _adminRepository.GetAllPatients(skip, page);
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _adminRepository.GetDoctorById(doctorId);
        }

        public Patient GetPatientById(int patientId)
        {
            return _adminRepository.GetPatientById(patientId);

        }

        public bool UpdateCoupon(Coupon changedCoupon)
        {
            throw new NotImplementedException();
        }
    }
}
