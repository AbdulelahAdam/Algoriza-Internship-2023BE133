using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
