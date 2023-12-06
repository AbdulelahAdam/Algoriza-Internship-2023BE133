using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class AdminRepository : IAdminRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        public AdminRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public bool AddCoupon(CouponPayload obj)
        {
            var newCoupon = new Coupon
            {
                DiscountCode = obj.DiscountCode,
                RequestsNumber = obj.RequestsNumber,
                DiscountType = obj.DiscountType,
                DiscountValue = obj.DiscountValue,
            };

            _context.Coupons.Add(newCoupon);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> AddDoctor(Doctor doctor)
        {
            //if(doctor.UserImage == null)
            //{
            //    return false;
            //}
            var password = doctor.PasswordHash;
            var hashedPass = new PasswordHasher<Doctor>().HashPassword(doctor, doctor.PasswordHash);
            doctor.PasswordHash = hashedPass;
            var result = await _userManager.CreateAsync(doctor);
            if (result.Succeeded)
            {
                //var emailSubject = "Hello, New User";
                //var emailBody = $"Welcome, {doctor.UserName}.\n\n This is you new account:\n Username: {doctor.UserName}\nPassword: {password}";
                //await _emailService.SendEmailAsync(doctor.Email, emailSubject, emailBody);
                return true;
            }
            return false;

        }



        public bool DeactivateCoupon(int id)
        {
            var coupon = _context.Coupons.Find(id);
            if (coupon != null)
            {
                coupon.DiscountCodeStatus = DiscountCodeStatus.DEACTIVATED;
                _context.SaveChanges();
                return true;
            }

            return false;
        }


        public bool DeleteCoupon(int id)
        {
            var coupon = _context.Coupons.Find(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteDoctor(string id)
        {
            Doctor doc = _context.Doctors.FirstOrDefault(d => d.Id == id);

            var docBookings = _context.Bookings.Where(b => b.DoctorId == id);
           
            if (doc != null && docBookings == null)
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

        public IEnumerable<Doctor> GetAllDoctors(int pageNumber, int pageSize, string search)
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
                .Where(d =>
                    d.UserName.Contains(search) ||
                    d.Email.Contains(search) ||
                    d.Id.Contains(search)
                )
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            return paginatedData;
        }

        public IEnumerable<Patient> GetAllPatients(int pageNumber, int pageSize, string search)
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
                .Where(p =>
                    p.UserName.Contains(search) ||
                    p.Email.Contains(search) ||
                    p.Id.Contains(search)
                )
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
