using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodTruckFinderWebApp.Models
{
    class FoodTruckProcessor
    {
        /// <summary>
        /// Aynchronous function for fetching results from the url string. Raises an exception if response was not successful.
        /// </summary>
        /// <returns> List of food trucks by the API</returns>
        public static async Task<List<FoodTruckModel>> LoadFoodTruckData(string url)
        {
            List<FoodTruckModel> foodTruck = null;
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    foodTruck = await response.Content.ReadAsAsync<List<FoodTruckModel>>();
                    return foodTruck;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        /// <summary>
        // Returns true if system day equal to food truck day order and system time between start and end time of food cart.
        /// </summary>
        /// <param name="currentSystemDayIndex">System day index 0:Sunday 1:Monday 2:Tuesday 3:Wednesday 4:Thursday 5:Friday 6:Saturday</param>
        /// <param name="currentSystemTime">System time in HH:MM format(24hr)</param>
        /// <param name="foodTruck">List of all food trucks</param>
        /// <returns>True if open and False if closed</returns>
        private static bool IsFoodTruckOpen(int currentSystemDayIndex, string currentSystemTime, FoodTruckModel foodTruck)
        {
            if (currentSystemDayIndex != foodTruck.DayOrder)
                return false;

            int systemTimeInMinutes = UtilityHelpers.ConvertToMinutes(currentSystemTime);
            int foodTruckStartTimeMinutes = UtilityHelpers.ConvertToMinutes(foodTruck.Start24);
            int foodTruckEndTimeMinutes = UtilityHelpers.ConvertToMinutes(foodTruck.End24);

            if (foodTruckStartTimeMinutes <= systemTimeInMinutes && foodTruckEndTimeMinutes > systemTimeInMinutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Public function that returns a list of open food trucks sorted by applicant.
        /// </summary>
        /// <param name="currentSystemDayIndex">System day index 0:Sunday 1:Monday 2:Tuesday 3:Wednesday 4:Thursday 5:Friday 6:Saturday</param>
        /// <param name="currentSystemTime">System time in HH:MM format(24hr)</param>
        /// <param name="foodTrucks">List of all food trucks</param>
        /// <returns>List of FoodTruckModel</returns>
        public static List<FoodTruckModel> GetOpenFoodTrucks(int currentSystemDayIndex, string currentSystemTime, List<FoodTruckModel> foodTrucks)
        {
            List<FoodTruckModel> openFoodTrucks = new List<FoodTruckModel>();

            foreach (var foodTruck in foodTrucks)
            {
                if (IsFoodTruckOpen(currentSystemDayIndex, currentSystemTime, foodTruck))
                {
                    openFoodTrucks.Add(foodTruck);
                }
            }

            openFoodTrucks = openFoodTrucks.OrderBy(o => o.Applicant).ToList();

            return openFoodTrucks;
        }
    }
}
