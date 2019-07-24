using CHAI.DataService.Contract;
using CHAI.DataService.DataProvider;
using CHAI.DataService.Model;
using System;
using System.Collections.Generic;

namespace CHAI.DataService.Repository
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
