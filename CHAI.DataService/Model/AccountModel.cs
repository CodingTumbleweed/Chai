using CHAI.DataService.Contract;
using CHAI.DataService.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAI.DataService.Model
{
    public class AccountModel : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MotherMaidenName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public bool IsUpdated { get; set; }

        private int _cityId;
        public int CityId
        {
            get { return _cityId == 0 ? Convert.ToInt32(DefaultValueStore.CityId) : _cityId; }
            set { _cityId = value; }
        }

        private int _stateId;
        public int StateId
        {
            get { return _stateId == 0 ? Convert.ToInt32(DefaultValueStore.StateId) : _stateId; }
            set { _stateId = value; }
        }

        private int _countryId;
        public int CountryId
        {
            get { return _countryId == 0 ? Convert.ToInt32(DefaultValueStore.CountryId) : _countryId; }
            set { _countryId = value; }
        }


    }
}
