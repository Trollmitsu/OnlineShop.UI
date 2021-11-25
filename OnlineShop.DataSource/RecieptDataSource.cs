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
    public class RecieptDataSource : IDataSource<RecieptDTO>
    {
        string path = @"C:\Users\Danis\source\repos\OnlineShop.UI\OnlineShop.DataSource\Reciept.JSON";

        public bool Delete(RecieptDTO _object)
        {
            throw new NotImplementedException();
        }

        public RecieptDTO GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Save(RecieptDTO _object)
        {
            {
            List<RecieptDTO> receipts = ShowAll().ToList();

            if (receipts.Count() == 0)
            {
                _object.RecieptNumber = 0;
            }
            else
            {
                _object.RecieptNumber = (receipts.Max(x => x.RecieptNumber) + 1);
            }
            receipts.Add(_object);
            File.WriteAllText(path, JsonConvert.SerializeObject(receipts));
            }
        }

        public IEnumerable<RecieptDTO> ShowAll()
        {
            return JsonConvert.DeserializeObject<List<RecieptDTO>>(File.ReadAllText(path));
        }

        public RecieptDTO Update(RecieptDTO currentobject)
        {
            throw new NotImplementedException();
        }
    }
}
