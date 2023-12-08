using Core.Models;

namespace Infrastructure.Interfaces
{
    public interface IDaysRepository
    {
        Days GetParsedDay(string day);
    }
}
