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
        string path = @"C:\Users\asus\source\repos\OnlineShop.UI\OnlineShop.DataSource\Order.JSON";

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
            OrderDTO newOrder = _object;
            List<OrderDTO> orders = ShowAll().ToList();
            int currentId = (orders.Last().OrderID + 1);
            newOrder.OrderID = currentId;
            orders.Add(newOrder);
            orders.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(orders));
        }

        public IEnumerable<OrderDTO> ShowAll()
        {
            return JsonConvert.DeserializeObject<List<OrderDTO>>(path);
        }

        public OrderDTO Update(OrderDTO currentobject)
        {
            OrderDTO newOrder = currentobject;
            List<OrderDTO> orders = ShowAll().ToList();
            orders.RemoveAll(oldOrder => oldOrder.OrderID == newOrder.OrderID);
            orders.Add(newOrder);
            orders.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(orders));
            return newOrder;
        }
    }
}
