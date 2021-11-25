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
    public class CustomerDataSource : IDataSource<CustomerDTO>
    {
        string path = @"C:\Users\Danis\source\repos\OnlineShop.UI\OnlineShop.DataSource\Customer.JSON";

        public bool Delete(CustomerDTO _object)
        {
            if (null != GetById(_object.CustomerId))
            {
                CustomerDTO newCustomer = _object;
                List<CustomerDTO> customers = ShowAll().ToList();
                customers.Remove(newCustomer);
                File.WriteAllText(path, JsonConvert.SerializeObject(customers));
                return true;
            }
            else return false;
        }

        public CustomerDTO GetById(int Id)
        {
            return JsonConvert.DeserializeObject<List<CustomerDTO>>(File.ReadAllText(path)).Find(u => u.CustomerId == Id);
        }

        public void Save(CustomerDTO _object)
        {

            CustomerDTO newCustomer = _object;
            List<CustomerDTO> customers = ShowAll().ToList();
            int currentId = (customers.Last().CustomerId + 1);
            newCustomer.CustomerId = currentId;
            customers.Add(newCustomer);
            customers.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(customers));
        }

        public IEnumerable<CustomerDTO> ShowAll()
        {
            
            return JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(File.ReadAllText(path));
        }

        public CustomerDTO Update(CustomerDTO currentobject)
        {
            throw new NotImplementedException();
        }
    }
}
