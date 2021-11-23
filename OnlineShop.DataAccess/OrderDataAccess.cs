using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public class OrderDataAccess : IDataAccess<OrderDTO>
    {
        private readonly IDataSource<OrderDTO> _dataSource;

        public OrderDataAccess(IDataSource<OrderDTO> dataSource) 
        {
            _dataSource = dataSource;
        }
        public void Delete(OrderDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public OrderDTO GetById(int Id)
        {
            return _dataSource.GetById(Id);
        }

        public OrderDTO Update(OrderDTO currentobject)
        {
            return _dataSource.Update(currentobject);
        }

        public void Save(OrderDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<OrderDTO> ShowAll()
        {
            return _dataSource.ShowAll();
        }
    }
}
