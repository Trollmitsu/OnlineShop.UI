using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DTO
{
    public class RecieptDTO
    {
        public int RecieptNumber { get; set; }
        public OrderDTO Order { get; set; }
    }
}
