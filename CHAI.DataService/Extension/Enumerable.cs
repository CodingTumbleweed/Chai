using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.DataService.Extension
{
    static class Enumerable
    {
        public static bool IsEmpty<T>(this IEnumerable<T> source) => source != null && source.Count() > 0;
    }
}
