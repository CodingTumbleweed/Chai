using Chai.Models.POCO;
using Chai.DataService.Contract;
using Chai.DataService.DataProvider;
using System;
using System.Collections.Generic;

namespace Chai.DataService.Repository
{
    public class CityRepository : IReadOnlyRepository<CityModel>
    {
        public CityModel Find(CityModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityModel> FindById(int id)
        {
            return DBContext.GetCities(id);
        }

        public IEnumerable<CityModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
