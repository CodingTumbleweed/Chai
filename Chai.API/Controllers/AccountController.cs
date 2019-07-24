using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CHAI.DataService.Repository;
using CHAI.DataService.Contract;
using CHAI.DataService.Model;
using Chai.API.Filters;

namespace Chai.API.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IRepository<AccountModel> _accountRepository;

        public AccountController()
        {
            _accountRepository = new AccountRepository();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns></returns>
        [HttpPost]
        [ModelValidationFilter]
        public IHttpActionResult AddUser(AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int Id = _accountRepository.Add(model);
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
        [ModelValidationFilter]
        public IHttpActionResult LoginUser([FromUri] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _accountRepository.Find(model);
            return Ok(result);
        }
    }
}
