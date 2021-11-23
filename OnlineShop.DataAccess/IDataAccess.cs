using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public interface IDataAccess<T>
    {
        public IEnumerable<T> ShowAll();
        public T Update(T currentobject);
        public T GetById(int Id);
        public void Save(T _object);
        public void Delete(T _object);

    }
}
