using Chai.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.Models.POCO
{
    public class BankModel : IEntity
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string BankCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string IBAN { get; set; }
        public string SwiftCode { get; set; }
        public string RoutingNumber { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
