using Chai.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.Models.POCO
{
    public class PaymentMethodModel : IEntity
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
