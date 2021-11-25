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
        string path = @"C:\Users\Danis\source\repos\OnlineShop.UI\OnlineShop.DataSource\ShoppingCart.JSON";

        public bool Delete(ShoppingCartDTO _object)
        {
            if (null != GetById(_object.Id))
            {
                ShoppingCartDTO newCart = _object;
                List<ShoppingCartDTO> Shoppingcarts = ShowAll().ToList();
                Shoppingcarts.Remove(newCart);
                File.WriteAllText(path, JsonConvert.SerializeObject(newCart));
                return true;
            }
            else return false;
        }

        public ShoppingCartDTO GetById(int Id)
        {
            return JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(File.ReadAllText(path)).Find(s => s.Id == Id);
        }

        public void Save(ShoppingCartDTO _object)
        {
            ShoppingCartDTO newCart = _object;
            List<ShoppingCartDTO> carts = ShowAll().ToList();
            carts.Add(newCart);
            File.WriteAllText(path, JsonConvert.SerializeObject(carts));
        }

        public IEnumerable<ShoppingCartDTO> ShowAll()
        {
            return JsonConvert.DeserializeObject<List<ShoppingCartDTO>>(File.ReadAllText(path));
        }

        public ShoppingCartDTO Update(ShoppingCartDTO currentobject)
        {
            ShoppingCartDTO newCart = currentobject;
            List<ShoppingCartDTO> cart = ShowAll().ToList();
            cart.RemoveAll(oldCart => oldCart.Id == newCart.Id);
            cart.Add(newCart);
            File.WriteAllText(path, JsonConvert.SerializeObject(cart));
            return newCart;
        }
    }
}
