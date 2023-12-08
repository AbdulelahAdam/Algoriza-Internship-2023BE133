using Core.Models;
using Infrastructure.Interfaces;

namespace Application
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _BookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _BookingRepository = bookingRepository;
        }

        public bool CancelBooking(int bookingId, string patientId)
        {
            return _BookingRepository.CancelBooking(bookingId, patientId);
        }

        public bool MakeBooking(BookingPayload obj, string patientId)
        {
            return _BookingRepository.MakeBooking(obj, patientId);
        }
    }
}
