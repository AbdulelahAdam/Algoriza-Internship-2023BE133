namespace Core.Models
{
    public interface IBookingService
    {
        bool MakeBooking(BookingPayload obj, string patientId);
        bool CancelBooking(int bookingId, string patientId);
    }
}
