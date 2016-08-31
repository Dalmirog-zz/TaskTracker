using System.Collections.Generic;
using TaskTracker.Entities;

namespace TaskTracker.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreeting { get; set; }
    }
}
