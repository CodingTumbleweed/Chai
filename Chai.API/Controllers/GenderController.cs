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
    public class GenderController : ApiController
    {
        private readonly IRepository<GenderModel> _repository;

        public GenderController(IRepository<GenderModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets List of Gender
        /// </summary>
        /// <returns>List of Gender</returns>
        [HttpGet]
        public IHttpActionResult GetGender()
        {
            var results = _repository.GetAll();
            if (results == null)
                return NotFound();
            return Ok(results);
        }
    }
}
