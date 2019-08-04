using Chai.DataService.Contract;
using Chai.DataService.DataProvider;
using Chai.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.DataService.Repository
{
    public class CountryRepository : IRepository<CountryModel>
    {
        public int Add(CountryModel model)
        {
            throw new NotSupportedException();
        }

        public CountryModel Find(CountryModel model)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<CountryModel> FindById(int id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<CountryModel> GetAll()
        {
            return DBContext.GetCountries();
        }

        public void Remove(CountryModel model)
        {
            throw new NotSupportedException();
        }

        public void Update(CountryModel model)
        {
            throw new NotSupportedException();
        }
    }
}
