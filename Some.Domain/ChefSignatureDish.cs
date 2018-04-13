using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some.Domain
{
    public class ChefSignatureDish
    {
        public int ChefId { get; set; }
        public int SignatureDishId { get; set; }

        public Chef Chef { get; set; }
        public SignatureDish SignatureDish { get; set; }
    }
}
