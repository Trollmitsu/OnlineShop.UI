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
    public class ShoppingcartModel : PageModel
    {
        public readonly IDataAccess<ProductDTO> prodAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;
        private readonly IDataAccess<ShoppingCartDTO> cartAccess;



        public CustomerDTO Customer { get; set; }
        public List<ProductDTO> ShoppingCart { get; set; }



        public ShoppingcartModel(IDataAccess<ProductDTO> prodAccess, IDataAccess<CustomerDTO> custAccess, IDataAccess<ShoppingCartDTO> cartAccess)
        {
            this.prodAccess = prodAccess;
            this.custAccess = custAccess;
            this.cartAccess = cartAccess;
        }
        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("CustomerId");
            if (id.HasValue)
            {
                ShoppingCartDTO userCart = cartAccess.GetById(id.Value);
                if (userCart == null)
                {
                    userCart = new(id.Value);
                    cartAccess.Save(userCart);
                    ShoppingCart = userCart.Products;
                    return Page();
                }
                else
                {
                    ShoppingCart = userCart.Products;
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Customers");
            }
        }
        public IActionResult OnPostRemove(int index)
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            ShoppingCartDTO userCart = cartAccess.GetById(Id.Value);
            userCart.Products.RemoveAt(index);
            cartAccess.Update(userCart);
            return RedirectToPage("/Shoppingcart");

        }

        public IActionResult OnPostAddToCart(int ProductId)
        {

            int? Id = HttpContext.Session.GetInt32("CustomerId");
            ShoppingCartDTO userCart = cartAccess.GetById(Id.Value);
            if (userCart == null)
            {
                userCart = new(Id.Value);
                ProductDTO product = prodAccess.GetById(ProductId);
                userCart.Products.Add(product);
                cartAccess.Save(userCart);
            }
            else
            {
                ProductDTO product = prodAccess.GetById(ProductId);
                userCart.Products.Add(product);
                cartAccess.Update(userCart);
            }
            return RedirectToPage("/Products");
        }

    }
}
