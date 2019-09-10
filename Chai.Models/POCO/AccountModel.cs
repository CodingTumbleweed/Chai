using Chai.Models.Contract;
using Chai.Models.Resource;
using System;
using System.ComponentModel.DataAnnotations;

namespace Chai.Models.POCO
{
    public class AccountModel : IEntity
    {
        public int Id { get; set; }
        public int CultureId { get; set; }
        [MaxLength(15, ErrorMessage = "Max 15 Alphabets Allowed")]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Provided Name is not valid")]
        public string FirstName { get; set; }
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Provided Name is not valid")]
        public string MiddleName { get; set; }
        [MaxLength(15, ErrorMessage = "Max 15 Alphabets Allowed")]
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Provided Name is not valid")]
        public string LastName { get; set; }
        public string MotherMaidenName { get; set; }
        [EmailAddress(ErrorMessage ="Provided Email is not valid")]
        public string Email { get; set; }
        //[MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$&*\^%\*\.])(?=.*[0-9])(?=.*[a-z]).{8,}$",
            ErrorMessage = "Password must have minimum 8 characters with at least one uppercase, lowercase, number and symbol")]
        public string Password { get; set; }
        public string Phone { get; set; }
        [StringLength(maximumLength:10, MinimumLength = 10, ErrorMessage = "Mobile number must be 10 characters long")]
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
        public int Code { get; set; }
        public string Message { get; set; }

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
