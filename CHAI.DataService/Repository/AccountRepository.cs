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
            throw new NotSupportedException();
        }

        public IEnumerable<AccountModel> GetAll()
        {
            throw new NotSupportedException();
        }

        public bool Remove(AccountModel model)
        {
            return DBContext.DeleteUser(model);
        }

        public bool Update(AccountModel model)
        {
            return DBContext.UpdateUser(model);
        }
    }
}
