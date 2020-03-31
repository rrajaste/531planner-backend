using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime[] StartingFromGetDatesWithSameDayOfWeek(this DateTime dateTime, ICollection<DateTime> baseDates)
        {
            var startOfWeek = dateTime.StartOfWeek(DayOfWeek.Monday);
            if (startOfWeek.AreAnyDaysOfWeekBeforeThis(baseDates))
            {
                startOfWeek = startOfWeek.AddDays(7);
            }
            var newDates = new DateTime[baseDates.Count];
            var oldDates = baseDates.ToList();
            for (var i = 0; i < baseDates.Count; i++)
            {
                newDates[i] = startOfWeek.AddDays(oldDates[i].DayOfWeek - startOfWeek.DayOfWeek);
            }

            return newDates;
        }

        private static bool AreAnyDaysOfWeekBeforeThis(this DateTime dateTime, IEnumerable<DateTime> dates)
        {
            return dates.Any(d => d.DayOfWeek < dateTime.DayOfWeek);
        }
        
        public static DateTime StartOfWeek(this DateTime dateTime, DayOfWeek startOfWeek)
        {
            var diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }
    }
}