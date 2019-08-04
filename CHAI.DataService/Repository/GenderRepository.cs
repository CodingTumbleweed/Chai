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
    public class GenderRepository : IRepository<GenderModel>
    {
        public int Add(GenderModel model)
        {
            throw new NotSupportedException();
        }

        public GenderModel Find(GenderModel model)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<GenderModel> FindById(int id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<GenderModel> GetAll()
        {
            return DBContext.GetGender();
        }

        public void Remove(GenderModel model)
        {
            throw new NotSupportedException();
        }

        public void Update(GenderModel model)
        {
            throw new NotSupportedException();
        }
    }
}
