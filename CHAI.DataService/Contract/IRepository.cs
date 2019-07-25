using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CHAI.DataService.Contract
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        int Add(T model);

        void Remove(T model);

        void Update(T model);
    }
}
