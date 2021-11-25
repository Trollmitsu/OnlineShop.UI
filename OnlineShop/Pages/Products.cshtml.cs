using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShop.DataAccess;
using OnlineShop.DTO;

namespace OnlineShop.Pages.Shared
{
    public class ProductsModel : PageModel
    {
        public readonly IDataAccess<ProductDTO> _dataAccess;
        public readonly IDataAccess<CustomerDTO> _custAccess;

        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        [BindProperty]
        public ProductDTO Product { get; set; }
        public int ProductID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ProductsModel(IDataAccess<ProductDTO> dataAccess, IDataAccess<CustomerDTO> custAccess)
        {
            _dataAccess = dataAccess;
            _custAccess = custAccess;
        }
        public IActionResult OnGet()
        {
            int? id = HttpContext.Session.GetInt32("CustomerId");
            if (id.HasValue)
            {
                Products = _dataAccess.ShowAll().ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("/Customers");
            }
        }
        public ActionResult OnPostSearch()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Products = _dataAccess.ShowAll().Where(p => p.ProductName.ToLower().Contains(SearchTerm.ToLower())).ToList();
                return Page();
            }
            return RedirectToPage("/Products");
        }
        public IActionResult OnPostAddToCart()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Shoppingcart");
            }
            return Page();
        }

        public IActionResult OnPostSortPriceUp()
        {
            Products = _dataAccess.ShowAll().ToList().OrderBy(p => p.Price).ToList();
            return Page();
        }
        public IActionResult OnPostSortPriceDown()
        {
            Products = _dataAccess.ShowAll().ToList().OrderByDescending(p => p.Price).ToList();
            return Page();
        }
    }
}
