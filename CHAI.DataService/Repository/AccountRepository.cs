using Chai.Models.POCO;
using Chai.DataService.Contract;
using Chai.DataService.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.DataService.Repository
{
    public class AccountRepository : IRepository<AccountModel>
    {
        public int Add(AccountModel model)
        {
            return DBContext.AddUser(model);
        }

        public AccountModel Find(AccountModel model)
        {
            return DBContext.LoginUser(model);
        }

        public IEnumerable<AccountModel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(AccountModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(AccountModel model)
        {
            throw new NotImplementedException();
        }
    }
}
