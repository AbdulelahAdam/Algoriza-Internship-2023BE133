using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Infrastructure.Interfaces;

namespace Infrastructure.Data
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public bool AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool EditDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int patientId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCoupon(Coupon changedCoupon)
        {
            throw new NotImplementedException();
        }

       
    }
}
