using Chai.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chai.API.Controllers
{
    public class CityController : ApiController
    {
        /// <summary>
        /// Gets List of all cities
        /// </summary>
        /// <returns>List of all cities</returns>
        [HttpGet]
        public IHttpActionResult GetAllCities()
        {
            IList<City> cities = new List<City>();
            cities.Add(new City() { Id =1, Name = "San Francisco", ISOCode = "SF", StateId = 1 });
            cities.Add(new City() { Id = 2, Name = "San Diego", ISOCode = "SD", StateId = 1 });
            cities.Add(new City() { Id = 3, Name = "Mexico", ISOCode = "MX", StateId = 1 });
            return Ok<IList<City>>(cities);
        }
    }
}
