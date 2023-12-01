namespace Core.Models
{
    public interface IBookingService
    {
        bool MakeBooking(string patientId, string doctorId, int timeSlotId);
    }
}
