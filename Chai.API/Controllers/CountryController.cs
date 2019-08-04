using Chai.DataService.Contract;
using Chai.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chai.API.Controllers
{
    public class CountryController : ApiController
    {
        private readonly IRepository<CountryModel> _repository;

        public CountryController(IRepository<CountryModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets List of all countries
        /// </summary>
        /// <returns>List of all countries</returns>
        [HttpGet]
        public IHttpActionResult GetAllCountries()
        {
            var results = _repository.GetAll();
            if (results == null)
                return NotFound();
            return Ok(results);
        }
    }
}
