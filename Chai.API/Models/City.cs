using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chai.API.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public int StateId { get; set; }
    }
}