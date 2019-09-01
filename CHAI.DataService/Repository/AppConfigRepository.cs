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
    public class AppConfigRepository : IRepository<AppConfigModel>
    {
        public int Add(AppConfigModel model)
        {
            throw new NotSupportedException();
        }

        public AppConfigModel Find(AppConfigModel model)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<AppConfigModel> FindById(int id)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<AppConfigModel> GetAll()
        {
            return DBContext.GetAppConfigSettings();
        }

        public bool Remove(int id)
        {
            throw new NotSupportedException();
        }

        public bool Update(AppConfigModel model)
        {
            throw new NotSupportedException();
        }
    }
}
