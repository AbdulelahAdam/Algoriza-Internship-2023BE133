using Core.Models;
using Infrastructure.Interfaces;

namespace Application
{
    public class DaysService : IDaysService
    {
        private readonly IDaysRepository _daysRepository;

        public DaysService(IDaysRepository daysRepository)
        {
            _daysRepository = daysRepository;
        }

        public Days GetParsedDay(string day)
        {
            return _daysRepository.GetParsedDay(day);
        }
    }
}
