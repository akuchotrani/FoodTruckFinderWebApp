using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckFinderWebApp.Models
{
    static class UtilityHelpers
    {
        /// <summary>
        /// Utility helper to convert time in HH::MM format into minutes.
        /// </summary>
        /// <param name="Time">HH:MM (24hr format)</param>
        /// <returns>total minutes</returns>
        public static int ConvertToMinutes(string Time)
        {
            var Parts = Time.Split(':');
            return Int32.Parse(Parts[0]) * 60 + Int32.Parse(Parts[1]);
        }

        /// <summary>
        /// Helper function to convert time to utc-8
        /// </summary>
        /// <param name="currentSystemTime"></param>
        /// <returns></returns>
        public static string ConvertToUtcMinus8(string currentSystemTime)
        {
            string result = "";
            var parts = currentSystemTime.Split(':');
            int hr = int.Parse(parts[0]);
            string minutes = parts[1];
            hr = (hr - 8) >= 0 ? (hr - 8) : 24 + (hr - 8);
            result = hr.ToString() + ":" + minutes;
            return result;
        }
    }
}
