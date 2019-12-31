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
    }
}
