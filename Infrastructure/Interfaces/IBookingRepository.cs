using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface IBookingRepository
    {
        bool MakeBooking(BookingPayload obj, string patientId);
        bool CancelBooking(int bookingId, string patientId);
    }
}
