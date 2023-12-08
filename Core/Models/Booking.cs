using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public int TimeSlotId { get; set; }

        public float BookingPrice { get; set; }
        public float FinalBookingPrice { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.PENDING;
        public DateTime CreatedAt { get; set; }

        public DateTime BookingDate { get; set; }

        public Doctor Doctor { get; set; }
    }
}