using Chai.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chai.Models.POCO
{
    public class AgencyModel : IEntity
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        public string AgencyCode { get; set; }
        public string Name { get; set; }
        public int AgencyStatusId { get; set; }
        public decimal AgencyBalance { get; set; }
        public int BalancePaymentMethodId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int Zip { get; set; }
        public int BankAccountId { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
