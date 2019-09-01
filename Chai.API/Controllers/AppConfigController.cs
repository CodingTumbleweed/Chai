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
    [Authorize]
    public class AppConfigController : ApiController
    {
        private readonly IRepository<AppConfigModel> _repository;

        public AppConfigController(IRepository<AppConfigModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets List of Application
        /// Configuration Settings 
        /// </summary>
        /// <returns>List of App Configuration Settings</returns>
        [HttpGet]
        public IHttpActionResult GetAppConfigs()
        {
            var results = _repository.GetAll();
            if (results == null)
                return NotFound();
            return Ok(results);
        }
    }
}
