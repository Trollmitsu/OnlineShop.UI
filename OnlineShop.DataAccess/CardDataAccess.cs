using OnlineShop.DataSource;
using OnlineShop.DTO;
using System;
using System.Collections.Generic;

namespace OnlineShop.DataAccess
{
    public class CardDataAccess : IDataAccess<CardDTO>
    {
        private readonly IDataSource<CardDTO> _dataSource;

        public CardDataAccess (IDataSource<CardDTO> dataSource)
        {
            _dataSource = dataSource;
        }
        public void Delete(CardDTO _object)
        {
            _dataSource.Delete(_object);
        }

        public CardDTO GetById(int Id)
        {
            return _dataSource.GetById(Id);
        }

        public CardDTO Update(CardDTO currentobject)
        {
            return _dataSource.Update(currentobject);
        }

        public void Save(CardDTO _object)
        {
            _dataSource.Save(_object);
        }

        public IEnumerable<CardDTO> ShowAll()
        {
            return _dataSource.ShowAll();
        }
    }
}
