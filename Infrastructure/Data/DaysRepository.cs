using Core.Models;
using Infrastructure.Interfaces;
using System;

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
