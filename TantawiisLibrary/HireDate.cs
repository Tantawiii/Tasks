using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TantawiisLibrary
{
    public struct HireDate
    {
        public int Day;
        public int Month;
        public int Year;

        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public string DisplayDate()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}
