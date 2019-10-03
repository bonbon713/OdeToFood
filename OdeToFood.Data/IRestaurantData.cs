using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        //IEnumerable<OdeToFood.Core.Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData: IRestaurantData
    {
        private List<Restaurant> restaurants = new List<Restaurant>();
        public InMemoryRestaurantData()
        {
            // This syntax is ugly and needs to go away
            //restaurants = new List<Restaurant>();
            //var restaurants1 = new Restaurant();
            //restaurants1.ID = 1;
            //restaurants1.Name = "taylor's Pizza";
            //restaurants1.Location = "dallas";
            //restaurants1.Cuisine = Restaurant.CuisineType.Italian;

            //restaurants.Add(restaurants1);



            restaurants = new List<Restaurant>()
            {
                new Restaurant{ ID = 1, Name = "Taylor's Pizza", Location = "Dallas", Cuisine=Restaurant.CuisineType.Italian },
                new Restaurant{ ID = 2, Name = "Bonnie's Enchiladas", Location = "Lewisville", Cuisine = Restaurant.CuisineType.Mexican },
                new Restaurant{ ID = 3, Name = "Kanwal's Butter Chicken", Location = "Plano", Cuisine=Restaurant.CuisineType.Indian },
            };
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant returnRestaurant = new Restaurant();
            foreach (var item in this.restaurants)
            {
                if (item.ID == id)
                {
                    returnRestaurant = item;
                    break;
                }
            }
            return returnRestaurant;
        }

        /// <summary>
        /// Try to find a match to the restaurant names
        /// </summary>
        /// <param name="searchInput">This is the term to search the list of restraurants</param>
        /// <returns></returns>
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
