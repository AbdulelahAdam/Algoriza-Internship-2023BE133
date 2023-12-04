using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Data
{
    public class AdminRepository : IAdminRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool AddCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddDoctor(Doctor doctor)
        {
            var hashedPass = new PasswordHasher<Doctor>().HashPassword(doctor, doctor.PasswordHash);
            doctor.PasswordHash = hashedPass;
            var result = await _userManager.CreateAsync(doctor);
            if (result.Succeeded)
            {
                return true;
            }
            return false;

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
            Doctor doc = _context.Doctors.FirstOrDefault(d => Convert.ToInt32(d.Id) == id);
            if (doc != null)
            {
                _context.Remove(doc);
                _context.SaveChanges();
                return true;
            }

            return false;
        }


        public bool EditDoctor(Doctor doctor)
        {
            var hashedPass = new PasswordHasher<Doctor>().HashPassword(doctor, doctor.PasswordHash);
            doctor.PasswordHash = hashedPass;
            var doc = _context.Doctors.Attach(doctor);
            doc.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Doctor> GetAllDoctors(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            int skip = (pageNumber - 1) * pageSize;


            var paginatedData = 
                _context.Doctors.Include(d => d.Appointments)
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }
        
        public IEnumerable<Doctor> GetAllDoctorsBySearch(string search)
        {
            IQueryable<Doctor> query = _context.Doctors.Include(d => d.Appointments);

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(d =>
                    d.UserName.Contains(search) ||
                    d.Email.Contains(search) ||
                    d.Id.Contains(search)
                );
            }


            return query;
        }
        

        public IEnumerable<Patient> GetAllPatients(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;  
            }

            int skip = (pageNumber - 1) * pageSize;

            var paginatedData = _context.Patients
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }

        public Doctor GetDoctorById(int doctorId)
        {
            Doctor doc = _context.Doctors
                .Include(d => d.Appointments)
                .FirstOrDefault(d => Convert.ToInt32(d.Id) == doctorId);
            
            if (doc != null)
            {
                return doc;
            }

            return null;
        }

        public Patient GetPatientById(int patientId)
        {
            var patient = _context.Patients.FirstOrDefault(d => Convert.ToInt32(d.Id) == patientId);
            if (patient != null)
            {
                return patient;
            }

            return null;
        }

        public bool UpdateCoupon(Coupon changedCoupon)
        {
            throw new NotImplementedException();
        }


    }
}
