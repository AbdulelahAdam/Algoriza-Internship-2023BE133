using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public TimeSlotService(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }

        public int GetTimeSlotIdForAppointmentTime(string appointmentTime)
        {
            return _timeSlotRepository.GetTimeSlotIdForAppointmentTime(appointmentTime);
        }
    }
}
