using Raindrop.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raindrop.Com.Commands
{
    public static class CTime
    {
        public static string Name = "time";
        public static string Info = "Shows the current time";
        public static bool NeedsParam = false;

        public static void Run()
        {
            Console.WriteLine($"{Time.TimeString(true, true, true)}\t{Time.MonthString()}" +
                $"/{Time.DayString()}/{Time.YearString()}");
        }
    }
}
