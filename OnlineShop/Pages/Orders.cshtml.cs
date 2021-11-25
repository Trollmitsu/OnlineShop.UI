using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.DataAccess;
using OnlineShop.DTO;

namespace OnlineShop.Pages
{
    public class OrdersModel : PageModel
    {
        public readonly IDataAccess<OrderDTO> orderAccess;
        public readonly IDataAccess<ShoppingCartDTO> cartAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;
        public readonly IDataAccess<CardDTO> cardAccess;
        public readonly IDataAccess<ProductDTO> prodAccess;
        private readonly IDataAccess<RecieptDTO> receiptAccess;

        [BindProperty]
        public int Id { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public CustomerDTO Customer { get; set; }


        public OrdersModel(IDataAccess<OrderDTO> orderAccess, IDataAccess<ShoppingCartDTO> cartAccess, IDataAccess<CustomerDTO> custAccess, IDataAccess<CardDTO> cardAccess, IDataAccess<ProductDTO> prodAccess, IDataAccess<RecieptDTO> receiptAccess)
        {
            this.orderAccess = orderAccess;
            this.cartAccess = cartAccess;
            this.custAccess = custAccess;
            this.cardAccess = cardAccess;
            this.prodAccess = prodAccess;
            this.receiptAccess = receiptAccess;
        }
        public IActionResult OnGetPlaceOrder()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            ShoppingCartDTO userCart = cartAccess.GetById(Id.Value);
            if (userCart == null)
            {
                return RedirectToPage("/Customers");
            }
            else
            {
                CustomerDTO Customer = custAccess.GetById(Id.Value);
                OrderDTO newOrder = new OrderDTO(0, Customer, userCart.Products);
                orderAccess.Save(newOrder);
                cartAccess.Update(new ShoppingCartDTO(Id.Value));
                return RedirectToPage("/Orders");
            }
        }

       
        public IActionResult OnGet()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            if (Id.HasValue)
            {
                Orders = orderAccess.ShowAll().Where(o => o.Customer.CustomerId == Id.Value).ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("/Customers");
            }


        }
        public IActionResult OnPostPay()
        {
            Orders = orderAccess.ShowAll().ToList();
            var order = orderAccess.GetById(Id);
            if (!order.IsPaid)
            {
                order.IsPaid = true;
                orderAccess.Update(order);
                receiptAccess.Save(new RecieptDTO() { Order = order });
            }

            return RedirectToPage("/Receipts");
        }
        public IActionResult OnPostReceipt()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Receipts");
            }
            else
            {
                return Page();
            }
        }
    }
}
