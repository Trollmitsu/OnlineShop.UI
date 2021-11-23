using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public class CustomerDataAccess : IDataAccess<CustomerDTO>
    {
        private readonly IDataSource<CustomerDTO> _dataSource;

        public CustomerDataAccess(IDataSource<CustomerDTO> dataSource)
        {
            _dataSource = dataSource;
            
        }
        public void Delete(CustomerDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public CustomerDTO GetById(int Id)
        {
            return _dataSource.GetById(Id);
        }

        public CustomerDTO Update(CustomerDTO currentobject)
        {
            return _dataSource.Update(currentobject);
        }

        public void Save(CustomerDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<CustomerDTO> ShowAll()
        {
           return _dataSource.ShowAll();
        }
    }
}
