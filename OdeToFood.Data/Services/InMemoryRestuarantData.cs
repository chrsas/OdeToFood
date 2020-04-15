using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestuarantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;

        public InMemoryRestuarantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Pizza",Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2, Name = "Nuddles",Cuisine = CuisineType.French},
                new Restaurant{Id = 3, Name = "Dumpling",Cuisine = CuisineType.Indian},
            };
        }

        public void Add(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
        }

        public Restaurant FirstOrDefault(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}
