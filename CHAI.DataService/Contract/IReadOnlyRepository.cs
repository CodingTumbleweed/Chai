using CHAI.DataService.DataProvider;
using System.Collections.Generic;
using System.Data;

namespace CHAI.DataService.Contract
{
    public interface IReadOnlyRepository<T> where T : class
    {
        //DBContext context { get; }
        IEnumerable<T> FindById(int id);
        T Find(T model);
        IEnumerable<T> GetAll();
    }
}
