using Chai.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHAI.DataService.Repository;
using CHAI.DataService.Contract;
using CHAI.DataService.Model;

namespace Chai.API.Controllers
{
    public class CityController : ApiController
    {
        private readonly IReadOnlyRepository<CityModel> _cityRepository;

        public CityController()
        {
            _cityRepository = new CityRepository();
        }
        
        /// <summary>
        /// Gets List of all cities
        /// </summary>
        /// <param name="id">State Id</param>
        /// <returns>List of all cities</returns>
        [HttpGet]
        public IHttpActionResult GetCitiesByState(int id)
        {
            var results = _cityRepository.FindById(id);
            return Ok(results);
        }
    }
}
