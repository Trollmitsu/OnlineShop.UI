using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DTO
{
    public class RecieptDTO
    {
        public string Reciept { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> Product { get; set; }
    }
}
