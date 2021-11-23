using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DataAccess
{
    public class RecieptDataAccess : IDataAccess<RecieptDTO>
    {
        private readonly IDataSource<RecieptDTO> _dataSource;

        public RecieptDataAccess(IDataSource<RecieptDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(RecieptDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public RecieptDTO GetById(int Id)
        {
            return _dataSource.GetById(Id);
        }

        public RecieptDTO Update(RecieptDTO currentobject)
        {
            return _dataSource.Update(currentobject);
        }

        public void Save(RecieptDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<RecieptDTO> ShowAll()
        {
            return _dataSource.ShowAll();
        }
    }
}
