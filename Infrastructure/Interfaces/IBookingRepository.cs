using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBookingRepository
    {
        bool MakeBooking(string patientId, string doctorId, int timeSlotId);
    }
}
