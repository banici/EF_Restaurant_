using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some.Domain
{
    public class Rating
    {
        public int Id { get; set; }
        public int MichelinStar { get; set; }
        public int OrdinaryStar { get; set; }
        public string GuestReview { get; set; }
        public Restaurant TheRestaurant { get; set; }
        public SignatureDish TheSignatureDish { get; set; }
        public int RestaurantId { get; set; }
        public int SignatureDishId { get; set; }
    }
}
