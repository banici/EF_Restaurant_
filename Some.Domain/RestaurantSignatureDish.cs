using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some.Domain
{
    public class RestaurantSignatureDish
    {
        public int RestaurantId { get; set; }
        public int SignatureDishId { get; set; }

        public Restaurant Restaurant { get; set; }
        public SignatureDish SignatureDish { get; set; }
    }
}
