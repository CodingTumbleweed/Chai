using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chai.DataService.Repository;
using Chai.DataService.Contract;
using Chai.API.Filters;
using Chai.Models.POCO;

namespace Chai.API.Controllers
{
    [ModelValidationFilter]
    public class AccountController : ApiController
    {
        private readonly IRepository<AccountModel> _repository;

        public AccountController(IRepository<AccountModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddUser(AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int Id = _repository.Add(model);
            if(Id == 0)
                return Ok();

            return Ok(Id);
        }

        /// <summary>
        /// Authenticates User Login
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult LoginUser([FromUri] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _repository.Find(model);
            return Ok(result);
        }
    }
}
