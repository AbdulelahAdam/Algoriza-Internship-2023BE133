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

        public bool UpdateCoupon(Coupon changedCoupon)
        {
            throw new NotImplementedException();
        }
    }
}
