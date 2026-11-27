using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCall
{
    internal static class GameTime
    {
        public const int HoursPerDay = 8;
        public const int WeekEnd = 40;   

        private static readonly string[] Days =
            { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };

        
        public static int DayOf(int time)
        {
            return time / HoursPerDay;
        }

        
        public static int HourOf(int time)
        {
            return 8 + time % HoursPerDay;
        }

        public static string DayName(int time)
        {
            return Days[DayOf(time)];
        }

       
        public static string FormatDeadline(int deadline, int now)
        {
            if (deadline == WeekEnd)
            {
                if (DayOf(now) == 4)
                {
                    return "16:00";
                }
                return "péntek 16:00";
            }

            if (deadline > WeekEnd)
            {
                int nextWeek = deadline - WeekEnd;
                return "jövő " + Days[DayOf(nextWeek)].ToLower() + " " + HourOf(nextWeek) + ":00";
            }

            if (DayOf(deadline) == DayOf(now))
            {
                return HourOf(deadline) + ":00";
            }

            return Days[DayOf(deadline)].ToLower() + " " + HourOf(deadline) + ":00";
        }
    }
}
