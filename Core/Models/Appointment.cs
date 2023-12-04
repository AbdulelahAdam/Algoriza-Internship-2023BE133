using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public Days? Day { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int TimeSlotId { get; set; }
        [Required]
        public string DoctorId { get; set; }
    }

}
