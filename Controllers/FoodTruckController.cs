using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTruckFinderWebApp.Models;
using FoodTruckFinderWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruckFinderWebApp.Controllers
{
    public class FoodTruckController : Controller
    {
        public IActionResult OpenFoodTrucks()
        {
            int currentSystemDayIndex = (int)System.DateTime.Now.DayOfWeek;
            string currentSystemTime = DateTime.Now.ToString("HH:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            string url = "https://data.sfgov.org/resource/jjew-r69b.json";

            ApiHelper.InitializeClient();
            List<FoodTruckModel> allFoodTrucks = Task.Run(() => FoodTruckProcessor.LoadFoodTruckData(url)).Result;
            List<FoodTruckModel> openFoodTrucks = FoodTruckProcessor.GetOpenFoodTrucks(currentSystemDayIndex, currentSystemTime, allFoodTrucks);
            int maxPageCounter = (int)Math.Ceiling((decimal)openFoodTrucks.Count / 10);
            FoodTruckViewModel foodTruckViewModel = new FoodTruckViewModel
            {
                allFoodTrucks = allFoodTrucks,
                openFoodTrucks = openFoodTrucks,
                currentPageCounter = 1,
                maxPageCounter = maxPageCounter
            };

            return View(foodTruckViewModel);
        }
    }
}