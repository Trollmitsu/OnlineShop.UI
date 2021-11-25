﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DTO
{
    public class ShoppingCartDTO
    {
        public int Id { get; set; }
        public List<ProductDTO> Products { get; set; }
        public string ImagePath { get; set; }
        public ShoppingCartDTO(int Id)
        {
            this.Id = Id;
            Products = new();
        }
    }
}
