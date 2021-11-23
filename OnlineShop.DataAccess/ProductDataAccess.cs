using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public class ProductDataAccess : IDataAccess<ProductDTO>
    {
        private readonly IDataSource<ProductDTO> _dataSource;

        public ProductDataAccess(IDataSource<ProductDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(ProductDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public ProductDTO GetById(int Id)
        {
            return _dataSource.GetById(Id);
        }

        public ProductDTO Update(ProductDTO currentobject)
        {
            return _dataSource.Update(currentobject);
        }

        public void Save(ProductDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<ProductDTO> ShowAll()
        {
            return _dataSource.ShowAll();
        }
    }
}
