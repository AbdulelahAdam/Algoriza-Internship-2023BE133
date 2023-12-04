using System.Collections.Generic;

namespace Core.Models
{
    public class AppointmentPayload
    {
        public float Price { get; set; }
        public Dictionary<string, List<string>> Appointments { get; set; }
    }


}
