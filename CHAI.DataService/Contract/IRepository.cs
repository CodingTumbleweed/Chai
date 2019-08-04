using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Chai.DataService.Contract
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        int Add(T model);

        bool Remove(int id);

        bool Update(T model);
    }
}
