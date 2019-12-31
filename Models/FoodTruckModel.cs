using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckFinderWebApp.Models
{
    public class FoodTruckModel
    {
        public int DayOrder { get; set; }
        public string DayOfWeek { get; set; }
        public string Location { get; set; }
        public string Start24 { get; set; }
        public string End24 { get; set; }
        public string Applicant { get; set; }
    }
}
