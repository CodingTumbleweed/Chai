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
using Chai.Models.DTO;
using AutoMapper;

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
            var result = _repository.Find(model);
            if (result != null)
                return Ok(Mapper.Map<AccountModel, AccountDTO>(result));
            else
                return NotFound();
        }


        /// <summary>
        /// Updates User Details
        /// </summary>
        /// <param name="model">User model</param>
        /// <returns>Boolean indicating
        /// account update success</returns>
        [HttpPut]
        public IHttpActionResult UpdateUser(AccountModel model)
        {
            var result = _repository.Update(model);
            return Ok(result);
        }


        /// <summary>
        /// Deletes User Account
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Boolean indicating
        /// account removal success</returns>
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var result = _repository.Remove(id);
            return Ok(result);
        }
    }
}
