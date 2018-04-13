using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some.Domain
{
    public class Restaurant
    {
        public Restaurant()
        {
            SignatureDishes = new List<RestaurantSignatureDish>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Rating Rating { get; set; }
        public List<RestaurantSignatureDish> SignatureDishes { get; set; }
    }
}
