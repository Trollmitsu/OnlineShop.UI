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
    public class CardDataSource : IDataSource<CardDTO>
    {
        string path = @"C:\Users\asus\source\repos\OnlineShop.UI\OnlineShop.DataSource\Card.JSON";

        public bool Delete(CardDTO _object)
        {
            throw new NotImplementedException();
        }

        public CardDTO GetById(int Id)
        {
            return JsonConvert.DeserializeObject<List<CardDTO>>(File.ReadAllText(path)).Find(c => c.CardId == Id);
        }

        public void Save(CardDTO _object)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CardDTO> ShowAll()
        {
            return JsonConvert.DeserializeObject<List<CardDTO>>(File.ReadAllText(path));
        }

        public CardDTO Update(CardDTO currentobject)
        {
            throw new NotImplementedException();
        }
    }
}
