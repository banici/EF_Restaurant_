using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Some.Domain
{
    public class Chef
    {
        public Chef()
        {
            SignatureDishes = new List<ChefSignatureDish>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public List<ChefSignatureDish> SignatureDishes { get; set; }
    }
}
