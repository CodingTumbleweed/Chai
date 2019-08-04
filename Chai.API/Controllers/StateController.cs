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
    public class StateController : ApiController
    {
        private readonly IRepository<StateModel> _repository;

        public StateController(IRepository<StateModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets List of all states
        /// </summary>
        /// <param name="id">Country Id</param>
        /// <returns>List of all states</returns>
        [HttpGet]
        public IHttpActionResult GetStateByCountry(int id)
        {
            var results = _repository.FindById(id);
            if (results == null)
                return NotFound();
            return Ok(results);
        }
    }
}
