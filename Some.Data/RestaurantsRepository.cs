using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Some.Domain;

namespace Some.Data
{
    public class RestaurantsRepository : GenericRepository<RestaurantContext, Restaurant>
    {
    }
}
