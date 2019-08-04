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
    public class StateRepository : IRepository<StateModel>
    {
        public int Add(StateModel model)
        {
            throw new NotSupportedException();
        }

        public StateModel Find(StateModel model)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<StateModel> FindById(int id)
        {
            return DBContext.GetStates(id);
        }

        public IEnumerable<StateModel> GetAll()
        {
            throw new NotSupportedException();
        }

        public bool Remove(int id)
        {
            throw new NotSupportedException();
        }

        public bool Update(StateModel model)
        {
            throw new NotSupportedException();
        }
    }
}
