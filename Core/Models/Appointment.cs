using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Days? Day { get; set; }

        public int TimeSlotId { get; set; }
        [Required]
        public string DoctorId { get; set; }
    }

}
