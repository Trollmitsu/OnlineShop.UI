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
    public class CustomersModel : PageModel
    {
        public readonly IDataAccess<CustomerDTO> _custAccess;
        public readonly IDataAccess<CardDTO> _cardAccess;
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public List<CustomerDTO> Customers { get; set; }
        [BindProperty]
        public CustomerDTO Customer { get; set; }
        [BindProperty]
        public List<CardDTO> Card { get; set; }
        [BindProperty]
        public int CustomerId { get; set; }

        public CustomersModel(IDataAccess<CustomerDTO> dataAccess, IDataAccess<CardDTO> cardAccess)
        {
            _custAccess = dataAccess;
            _cardAccess = cardAccess;
            
        }
        public void OnGet()
        {
            Customers = _custAccess.ShowAll().ToList();
            Customer = _custAccess.GetById(CustomerId);
        }
        public IActionResult OnPostCustomer()
        {
            Customer = _custAccess.GetById(Customer.CustomerId);
            HttpContext.Session.SetInt32("CustomerId", Customer.CustomerId);
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Products");
            }
            return Page();
        }


    }
}