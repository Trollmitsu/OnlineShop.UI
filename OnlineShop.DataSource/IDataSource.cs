using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataSource
{
    public interface IDataSource<T>
    {
        public IEnumerable<T> ShowAll();
        public T Update(T currentobject);
        public T GetById(int Id);
        public void Save(T _object);
        public bool Delete(T _object);
    }
}
