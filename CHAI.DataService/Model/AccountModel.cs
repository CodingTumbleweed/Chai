using CHAI.DataService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAI.DataService.Model
{
    class AccountModel : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherMaidenName { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Zip { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public bool IsUpdated { get; set; }


    }
}
