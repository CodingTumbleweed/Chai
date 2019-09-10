using Chai.Models.POCO;
using Chai.DataService.Contract;
using Chai.DataService.DataProvider;
using System;
using System.Collections.Generic;

namespace Chai.DataService.Repository
{
    public class CityRepository : IRepository<CityModel>
    {
        public int Add(CityModel model)
        {
            throw new NotSupportedException();
        }

        public CityModel Find(CityModel model)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<CityModel> FindById(int id)
        {
            return DBContext.GetCities(id);
        }

        public IEnumerable<CityModel> GetAll()
        {
            throw new NotSupportedException();
        }

        public bool Remove(CityModel model)
        {
            throw new NotSupportedException();
        }

        public bool Update(CityModel model)
        {
            throw new NotSupportedException();
        }
    }
}
