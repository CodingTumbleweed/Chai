using Chai.DataService.DataProvider;
using System.Collections.Generic;
using System.Data;

namespace Chai.DataService.Contract
{
    public interface IReadOnlyRepository<T> where T : class
    {
        //DBContext context { get; }
        IEnumerable<T> FindById(int id);
        T Find(T model);
        IEnumerable<T> GetAll();
    }
}
