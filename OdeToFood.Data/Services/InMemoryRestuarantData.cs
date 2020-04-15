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

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var dbEntity = _restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            if(dbEntity == null)
                throw new Exception("对象不存在");
            dbEntity.Name = restaurant.Name;
            dbEntity.Cuisine = restaurant.Cuisine;
        }
    }
}
