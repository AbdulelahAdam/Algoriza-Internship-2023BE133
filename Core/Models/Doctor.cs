using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{

    public class Doctor : ApplicationUser
    {
        [Required]
        public int SpecializationId { set; get; }      
        
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}