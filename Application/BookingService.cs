using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _BookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _BookingRepository = bookingRepository;
        }

        public bool MakeBooking(BookingPayload obj, string patientId)
        {
            return _BookingRepository.MakeBooking(obj, patientId);
        }
    }
}
