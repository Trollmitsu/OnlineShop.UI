using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public class ShoppingCartDataAccess : IDataAccess<ShoppingCartDTO>
    {
        private readonly IDataSource<ShoppingCartDTO> _dataSource;

        public ShoppingCartDataAccess(IDataSource<ShoppingCartDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(ShoppingCartDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public ShoppingCartDTO GetById(int Id)
        {
            return _dataSource.GetById(Id);
        }

        public ShoppingCartDTO Update(ShoppingCartDTO currentobject)
        {
            return _dataSource.Update(currentobject);
        }

        public void Save(ShoppingCartDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<ShoppingCartDTO> ShowAll()
        {
            return _dataSource.ShowAll();
        }
    }
}
