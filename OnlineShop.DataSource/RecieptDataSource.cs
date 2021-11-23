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
        string path = @"C:\Users\asus\source\repos\OnlineShop.UI\OnlineShop.DataSource\Reciept.JSON";

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
            RecieptDTO newReciept = _object; ;
            List<RecieptDTO> reciepts = ShowAll().ToList();
            string currentReciept = (reciepts.Last().Reciept + 1);
            newReciept.Reciept = currentReciept;
            reciepts.Add(newReciept);
            reciepts.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(reciepts));
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
