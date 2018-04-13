using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Some.Data;
using Some.Domain;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class SingleObjectModification
    {
        private static RestaurantContext _context = new RestaurantContext();

        public static void DeleteMany()
        {
            var restRepo = new RestaurantsRepository();
            var restaurant = restRepo.GetAll().Where(b => b.Name.StartsWith("Kitchen")).ToList();
            restRepo.DeleteRange(restaurant);
            restRepo.Save(); ;
        }

        public static void Update()
        {
            var chefRepo = new ChefsRepository();
            var chef = chefRepo.FindBy(m => m.Name.StartsWith("Leif")).FirstOrDefault();
            chef.Name = "Tommy Myllymäki";
            chefRepo.Update(chef);
            chefRepo.Save();
        }

        public static void AddDishToRestaurant(string restName, string dishName)
        {
            var restRepo = new RestaurantsRepository();
            var rest = restRepo.FindBy(m => m.Name.StartsWith(restName)).FirstOrDefault();

            var dishRepo = new SignatureDishesRepository();
            var dish = dishRepo.FindBy(b => b.Name.StartsWith(dishName)).FirstOrDefault();

            var context = new RestaurantContext();
            context.Add(new RestaurantSignatureDish { SignatureDishId = dish.Id, RestaurantId = rest.Id });
            context.SaveChanges();
        }

        public static void AddMultipleDishes()
        {
            var dishRepo = new SignatureDishesRepository();
            dishRepo.AddRange(new List<SignatureDish> { new SignatureDish { Name = "räkmacka"},
                              new SignatureDish { Name = "bananasplit"}, 
                              new SignatureDish { Name = "hamburgare"},
                              new SignatureDish { Name = "pasta"} });
            dishRepo.Save();
        }

        public static void AddSignatureDish()
        {
            var dishRepo = new SignatureDishesRepository();
            dishRepo.Add(new SignatureDish { Name = "Beef Wellington"});
            dishRepo.Save();
            Console.WriteLine("Dish has been added to the list");
        }

        public static void FindChef(string chefName)
        {
            var chefRepo = new ChefsRepository();
            var chef = chefRepo.FindBy(m => m.Name.StartsWith(chefName)).FirstOrDefault();
            Console.WriteLine("Full name: " + chef.Name);
        }

        public static void ListOfAll()
        {
            var chefRepo = new ChefsRepository();
            var chefList = chefRepo.GetAll().ToList();
            foreach (var chef in chefList)
            {
                Console.WriteLine(chef.Name);
            }
        }
    }
}
