using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Some.Data;
using Some.Domain;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleObjectModification.AddDishToRestaurant("Hells Kitchen", "Risotto");
            //SingleObjectModification.Update();
            //SingleObjectModification.AddMultipleDishes();
            //SingleObjectModification.AddSignatureDish();
            //SingleObjectModification.FindChef("name");
            //SingleObjectModification.ListOfAll();
            //SingleObjectModification.DeleteMany();

            Console.WriteLine("Starting the process");
            LoadAllChefs();
            Thread thread1 = new Thread(SingleObjectModification.AddMultipleDishes);
            Waiting();
            thread1.Start();
            Console.WriteLine("Adding more Chefs to the kitchen");
            NewChefs();
            Console.WriteLine("Done");


            Console.ReadKey();
        }
        public static async void LoadAllChefs()
        {
            await Task.Run(new Action(SingleObjectModification.ListOfAll));
            Console.WriteLine("\n" + "Loading completed, proceeding to next");
            await Task.Run(new Action(SingleObjectModification.Update));
        }
        private static void Waiting()
        {
            Console.WriteLine("Lets Add more food, in 5 sec");
            Thread.Sleep(5000);
        }

        public static void AddMoreChefs()
        {
            var chefRepo = new ChefsRepository();
            chefRepo.AddRange(new List<Chef> { new Chef { Name = "Johan Skoglund"},
                              new Chef { Name = "Maraca Essos"},
                              new Chef { Name = "Guy Fieri"} });
            chefRepo.Save();
        }

        public static async void NewChefs()
        {
            await Task.Run(new Action(AddMoreChefs));
            Console.WriteLine("Done adding chefs");

            Console.WriteLine("lets have a look at the chef list");
            await Task.Run(new Action(SingleObjectModification.ListOfAll));
        }
    }
}
