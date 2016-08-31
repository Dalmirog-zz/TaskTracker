using System.Collections.Generic;
using TaskTracker.Entities;

namespace TaskTracker.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
    public class InMemotyRestaurantData : IRestaurantData
    {
        public InMemotyRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name="Tersigule's" },
                new Restaurant {Id = 2, Name="LJ's and the Kay" },
                new Restaurant {Id = 3, Name="King's Contrivance" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        List<Restaurant> _restaurants;
    }
}
