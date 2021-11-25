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
    public class ReceiptsModel : PageModel
    {
        private readonly IDataAccess<RecieptDTO> receiptAccess;
        public readonly IDataAccess<CustomerDTO> custAccess;
        public readonly IDataAccess<CardDTO> cardAccess;
        public readonly IDataAccess<OrderDTO> orderAccess;


        public List<RecieptDTO> Receipts { get; set; }
        public ReceiptsModel(IDataAccess<RecieptDTO> receiptAccess, IDataAccess<CustomerDTO> custAccess, IDataAccess<CardDTO> cardAccess)
        {
            this.receiptAccess = receiptAccess;
            this.custAccess = custAccess;
            this.cardAccess = cardAccess;
        }
        public void OnGet()
        {
            int? Id = HttpContext.Session.GetInt32("CustomerId");
            Receipts = receiptAccess.ShowAll().ToList().Where(x => x.Order.Customer.CustomerId == Id).ToList();
        }

    }
}
