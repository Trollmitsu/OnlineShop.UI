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
    public class OrderDataSource : IDataSource<OrderDTO>
    {
        string path = @"C:\Users\Danis\source\repos\OnlineShop.UI\OnlineShop.DataSource\Order.JSON";

        public bool Delete(OrderDTO _object)
        {
            if (null != GetById(_object.OrderID))
            {
                OrderDTO newOrder = _object;
                List<OrderDTO> orders = ShowAll().ToList();
                orders.RemoveAll(OldUser => OldUser.OrderID == newOrder.OrderID);
                orders.Sort();
                File.WriteAllText(path, JsonConvert.SerializeObject(orders));
                return true;
            }
            else return false;
        }

        public OrderDTO GetById(int Id)
        {
            return JsonConvert.DeserializeObject<List<OrderDTO>>(File.ReadAllText(path)).Find(o => o.OrderID == Id);
        }

        public void Save(OrderDTO _object)
        {
            List<OrderDTO> orders = ShowAll().ToList();
            if (orders.Count() == 0)
            {
                _object.OrderID = 0;
            }
            else
            {
                _object.OrderID = (orders.Max(x => x.OrderID) + 1);
            }
            orders.Add(_object);
            File.WriteAllText(path, JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        public IEnumerable<OrderDTO> ShowAll()
        {
            return JsonConvert.DeserializeObject<List<OrderDTO>>(File.ReadAllText(path));
        }

        public OrderDTO Update(OrderDTO currentobject)
        {
            List<OrderDTO> orders = ShowAll().ToList();
            orders.RemoveAll(oldOrder => oldOrder.OrderID == currentobject.OrderID);
            orders.Add(currentobject);
            File.WriteAllText(path, JsonConvert.SerializeObject(orders));
            return currentobject;
        }
    }
}
