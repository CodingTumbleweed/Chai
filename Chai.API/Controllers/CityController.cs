using Chai.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHAI.DataService.Repository;

namespace Chai.API.Controllers
{
    public class CityController : ApiController
    {
        /// <summary>
        /// Gets List of all cities
        /// </summary>
        /// <returns>List of all cities</returns>
        [HttpGet]
        public IHttpActionResult GetCitiesByState(int id)
        {
            CityRepository cityRepository = new CityRepository();
            var results = cityRepository.FindById(id);
            return Ok(results);
        }
    }
}
