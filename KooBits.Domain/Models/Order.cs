using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KooBits.Domain.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
