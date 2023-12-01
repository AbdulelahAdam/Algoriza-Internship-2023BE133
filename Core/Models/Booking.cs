using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Booking
    {
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string DoctorId { get; set; }
        [Required]
        public int TimeSlotId { get; set; }


    }
}