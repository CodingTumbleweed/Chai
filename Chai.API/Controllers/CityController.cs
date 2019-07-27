using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chai.DataService.Repository;
using Chai.DataService.Contract;
using Chai.Models.POCO;
using Chai.API.Filters;

namespace Chai.API.Controllers
{
    [ModelValidationFilter]
    public class CityController : ApiController
    {
        private readonly IRepository<CityModel> _repository;

        public CityController(IRepository<CityModel> repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// Gets List of all cities
        /// </summary>
        /// <param name="id">State Id</param>
        /// <returns>List of all cities</returns>
        [HttpGet]
        public IHttpActionResult GetCitiesByState(int id)
        {
            var results = _repository.FindById(id);
            if (results == null)
                return NotFound();
            return Ok(results);
        }
    }
}
