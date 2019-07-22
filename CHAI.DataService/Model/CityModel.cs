using CHAI.DataService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAI.DataService.Model
{
    public class CityModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
    }
}
