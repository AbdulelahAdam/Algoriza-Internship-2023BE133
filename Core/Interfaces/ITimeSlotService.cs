namespace Core.Models
{
    public interface ITimeSlotService
    {
        int GetTimeSlotIdForAppointmentTime(string appointmentTime);
    }

}
