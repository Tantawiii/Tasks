using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{
    using System;

    public class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        private void Normalize()
        {
            if (Seconds >= 60 || Seconds <= -60)
            {
                Minutes += Seconds / 60;
                Seconds %= 60;
            }
            if (Seconds < 0)
            {
                Seconds += 60;
                Minutes--;
            }

            if (Minutes >= 60 || Minutes <= -60)
            {
                Hours += Minutes / 60;
                Minutes %= 60;
            }
            if (Minutes < 0)
            {
                Minutes += 60;
                Hours--;
            }
        }


        public Duration() : this(0, 0, 0) { }

        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
            Normalize();
        }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            //Normalize();
        }

        public override string ToString()
        {
            string result = "";
            if (Hours != 0) result += $"Hours: {Hours}, ";
            if (Minutes != 0 || Hours != 0) result += $"Minutes: {Minutes}, ";
            result += $"Seconds: {Seconds}";
            return result;
        }

        public static Duration operator -(Duration d)
        {
            return new Duration(-d.Hours, -d.Minutes, -d.Seconds);
            //return new Duration(-d.ToTotalSeconds());
        }


        public static Duration operator +(Duration d1, Duration d2)
        {
            var result = new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
            result.Normalize();
            return result;
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.ToTotalSeconds() + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return new Duration(d.ToTotalSeconds() + seconds);
        }

        public static Duration operator ++(Duration d)
        {
            var result = new Duration(d.Hours, d.Minutes, d.Seconds + 60);
            result.Normalize();
            return result;
        }

        public static Duration operator --(Duration d)
        {
            var result = new Duration(d.Hours, d.Minutes, d.Seconds - 60);
            result.Normalize();
            return result;
        }


        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() > d2.ToTotalSeconds();
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() < d2.ToTotalSeconds();
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() >= d2.ToTotalSeconds();
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
        }

        public override bool Equals(object obj)
        {
            if (obj is Duration other)
            {
                return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public static explicit operator DateTime(Duration d)
        {
            try
            {
                if (d.Hours < 0 || d.Minutes < 0 || d.Seconds < 0)
                {
                    d = new Duration(Math.Abs(d.Hours), Math.Abs(d.Minutes), Math.Abs(d.Seconds));
                }

                int hours = d.Hours % 24;
                int days = d.Hours / 24;

                const int maxDaysRepresentable = 3652058;
                if (days >= maxDaysRepresentable)
                {
                    throw new OverflowException("Duration exceeds the maximum representable range for a DateTime.");
                }

                DateTime result = new DateTime(1, 1, 1)
                    .AddDays(days)
                    .AddHours(hours)
                    .AddMinutes(d.Minutes)
                    .AddSeconds(d.Seconds);

                return result;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Duration cannot be converted to a DateTime: {ex.Message}");
                throw;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Duration exceeds DateTime limits: {ex.Message}");
                throw;
            }
        }


        public static implicit operator bool(Duration d)
        {
            return d.ToTotalSeconds() > 0;
        }

        private int ToTotalSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }
    }
}
