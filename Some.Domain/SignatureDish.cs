using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some.Domain
{
    public class SignatureDish
    {
        public SignatureDish()
        {
            Chefs = new List<ChefSignatureDish>();
            Restaurants = new List<RestaurantSignatureDish>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Rating Rating { get; set; }
        public List<ChefSignatureDish> Chefs { get; set; }
        public List<RestaurantSignatureDish> Restaurants { get; set; }
    }
}
