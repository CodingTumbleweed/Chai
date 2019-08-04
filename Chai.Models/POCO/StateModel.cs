using Chai.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.Models.POCO
{
    public class StateModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
    }
}
