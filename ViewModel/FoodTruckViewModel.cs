using FoodTruckFinderWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckFinderWebApp.ViewModel
{
    public class FoodTruckViewModel
    {

        public List<FoodTruckModel> allFoodTrucks { get; set; }
        public List<FoodTruckModel> openFoodTrucks { get; set; }
        public int currentPageCounter { get; set; }
        public int maxPageCounter { get; set; }

        public int CalculateDisplayStartIndex()
        {
            return (currentPageCounter - 1) * 10;
        }

        public int CalculateDisplayEndIndex()
        {
            return Math.Min(10 * currentPageCounter, openFoodTrucks.Count);
        }
    }
}
