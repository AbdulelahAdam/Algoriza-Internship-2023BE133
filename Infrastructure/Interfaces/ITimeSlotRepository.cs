
namespace Infrastructure.Interfaces
{
    public interface ITimeSlotRepository
    {
        int GetTimeSlotIdForAppointmentTime(string appointmentTime);
    }
}
