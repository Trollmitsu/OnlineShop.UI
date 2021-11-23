using Newtonsoft.Json;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataSource
{
    public class ShoppingCartDataSource : IDataSource<ShoppingCartDTO>
    {
        string path = @"C:\Users\asus\source\repos\OnlineShop.UI\OnlineShop.DataSource\ShoppingCart.JSON";

        public bool Delete(ShoppingCartDTO _object)
        {
            throw new NotImplementedException();
        }

        public ShoppingCartDTO GetById(int Id)
        {
            return JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(File.ReadAllText(path)).Find(s => s.Customer.CustomerId == Id);
        }

        public void Save(ShoppingCartDTO _object)
        {
            ShoppingCartDTO newCart = _object;
            List<ShoppingCartDTO> carts = ShowAll().ToList();
            int currentId = (carts.Last().Customer.CustomerId + 1);
            newCart.Customer.CustomerId = currentId;
            carts.Add(newCart);
            carts.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(carts));
        }

        public IEnumerable<ShoppingCartDTO> ShowAll()
        {
            throw new NotImplementedException();
        }

        public ShoppingCartDTO Update(ShoppingCartDTO currentobject)
        {
            ShoppingCartDTO newCart = currentobject;
            List<ShoppingCartDTO> cart = ShowAll().ToList();
            cart.RemoveAll(oldCart => oldCart.Customer.CustomerId == newCart.Customer.CustomerId);
            cart.Add(newCart);
            cart.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(cart));
            return newCart;
        }
    }
}
