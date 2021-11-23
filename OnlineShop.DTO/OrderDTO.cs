using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DTO
{
    public class OrderDTO
    {
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Product { get; set; }
        public int OrderID { get; set; }

        public RecieptDTO Reciept { get; set; }


    }
}
