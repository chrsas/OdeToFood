using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = restaurantData.GetAll();
            return View(model);
        }

        [HttpGet()]
        public ActionResult Details(int id)
        {
            var model = restaurantData.FirstOrDefault(id);
            if (model == null)
                return View("NotFound");
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            restaurantData.Add(restaurant);
            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
        }
    }
}