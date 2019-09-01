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
    public class PasswordRepository : IRepository<PasswordRecoveryModel>
    {
        public int Add(PasswordRecoveryModel model)
        {
            throw new NotImplementedException();
        }

        public PasswordRecoveryModel Find(PasswordRecoveryModel model)
        {
            return DBContext.InitiatePasswordRecovery(model.Email);
        }

        public IEnumerable<PasswordRecoveryModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PasswordRecoveryModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PasswordRecoveryModel model)
        {
            return DBContext.ValidatePasswordRecovery(model);
        }
    }
}
