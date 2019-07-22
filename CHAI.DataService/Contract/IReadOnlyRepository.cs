using CHAI.DataService.DataProvider;
using System.Collections.Generic;
using System.Data;

namespace CHAI.DataService.Contract
{
    internal interface IReadOnlyRepository<T> where T : class, IEntity
    {
        //DBContext context { get; }
        IEnumerable<T> FindById(int id);
        IEnumerable<T> GetAll();
    }
}
