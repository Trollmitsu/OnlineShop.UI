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
        public List<ProductDTO> Products { get; set; }
        public int OrderID { get; set; }

        public bool IsPaid { get; set; }
        public RecieptDTO Reciept { get; set; }

        public OrderDTO(int OrderID, CustomerDTO Customer, List<ProductDTO> Products)
        {
            this.OrderID = OrderID;
            this.Customer = Customer;
            this.Products = Products;
        }
    }
}
