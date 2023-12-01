using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DaysRepository : IDaysRepository
    {
        public Days GetParsedDay(string day)
        {
            Enum.TryParse(day.ToUpper(), out Days parsedDay);
            return parsedDay;
        }
    }
}
