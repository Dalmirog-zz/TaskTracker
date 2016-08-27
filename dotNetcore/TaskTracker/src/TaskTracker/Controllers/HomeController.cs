using Microsoft.AspNet.Mvc;
using TaskTracker.Models;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restraurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restraurantData = restaurantData;
        }
        public ViewResult Index()
        {
            var model = _restraurantData.GetAll();

            return View(model);
        }
    }
}
