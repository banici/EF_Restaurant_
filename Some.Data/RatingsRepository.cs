using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Some.Domain;

namespace Some.Data
{
    public class RatingsRepository : GenericRepository<RestaurantContext, Rating>
    {
        public Rating FindByPoints(int points)
        {
            var context = new RestaurantContext();
            var rating = context.Ratings.Where(r => r.MichelinStar == points).FirstOrDefault();
            return rating;
        }
    }
}
