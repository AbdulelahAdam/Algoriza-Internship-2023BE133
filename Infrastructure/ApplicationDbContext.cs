using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients{ get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Booking> Bookings{ get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Doctor>()
            //.HasOne(d => d.Specialization)
            //.WithMany(s => s.Doctors)
            //.HasForeignKey(d => d.SpecializationId)
            //.IsRequired();

            //modelBuilder.Entity<Doctor>()
            //.HasMany(d => d.Appointments)
            //.WithOne(a => a.Doctor)
            //.HasForeignKey(a => a.DoctorId)
            //.IsRequired();

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.TimeSlot)
            //    .WithMany()
            //    .HasForeignKey(a => a.TimeSlotId)
            //    .IsRequired();

            //modelBuilder.Entity<Appointment>()
            //.Property(a => a.Id)
            //.ValueGeneratedOnAdd();
            var admin = new Admin
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            admin.PasswordHash = new PasswordHasher<Admin>().HashPassword(admin, "AdminPassword123");

            modelBuilder.Entity<Admin>().HasData(admin);



            modelBuilder.Entity<Specialization>().HasData(
            new Specialization { Id = 1, Name = "Allergy and Immunology" },
            new Specialization { Id = 2, Name = "Anesthesiology" },
            new Specialization { Id = 3, Name = "Cardiology" },
            new Specialization { Id = 4, Name = "Cardiothoracic Surgery" },
            new Specialization { Id = 5, Name = "Dermatology" },
            new Specialization { Id = 6, Name = "Diagnostics" },
            new Specialization { Id = 7, Name = "Emergency Medicine" },
            new Specialization { Id = 8, Name = "Endocrinology" },
            new Specialization { Id = 9, Name = "Family Medicine" },
            new Specialization { Id = 10, Name = "Gastroenterology" },
            new Specialization { Id = 11, Name = "General Surgery" },
            new Specialization { Id = 12, Name = "Geriatrics" },
            new Specialization { Id = 13, Name = "Hematology" },
            new Specialization { Id = 14, Name = "Infectious Disease" },
            new Specialization { Id = 15, Name = "Internal Medicine" },
            new Specialization { Id = 16, Name = "Medical Genetics" },
            new Specialization { Id = 17, Name = "Nephrology" },
            new Specialization { Id = 18, Name = "Neurology" },
            new Specialization { Id = 19, Name = "Neurosurgery" },
            new Specialization { Id = 20, Name = "Obstetrics and Gynecology" },
            new Specialization { Id = 21, Name = "Oncology" },
            new Specialization { Id = 22, Name = "Ophthalmology" },
            new Specialization { Id = 23, Name = "Orthopedic Surgery" },
            new Specialization { Id = 24, Name = "Otolaryngology (ENT - Ear, Nose, and Throat)" },
            new Specialization { Id = 25, Name = "Pathology" },
            new Specialization { Id = 26, Name = "Pediatrics" },
            new Specialization { Id = 27, Name = "Physical Medicine and Rehabilitation" },
            new Specialization { Id = 28, Name = "Plastic Surgery" },
            new Specialization { Id = 29, Name = "Psychiatry" },
            new Specialization { Id = 30, Name = "Pulmonology" },
            new Specialization { Id = 31, Name = "Radiation Oncology" },
            new Specialization { Id = 32, Name = "Radiology" },
            new Specialization { Id = 33, Name = "Rheumatology" },
            new Specialization { Id = 34, Name = "Sports Medicine" },
            new Specialization { Id = 35, Name = "Thoracic Surgery" },
            new Specialization { Id = 36, Name = "Urology" }
        );

        }

    }
}