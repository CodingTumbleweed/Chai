using Chai.API.Filters;
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
    [ModelValidationFilter]
    public class PasswordController : ApiController
    {
        private readonly IRepository<PasswordRecoveryModel> _repository;

        public PasswordController(IRepository<PasswordRecoveryModel> repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Initiate a password recovery request
        /// for user account
        /// </summary>
        [HttpGet]
        public IHttpActionResult InitiateRecoveryRequest(string email)
        {
            var result = _repository.Find(new PasswordRecoveryModel { Email = email});
            return Ok(result);
        }
        

        /// <summary>
        /// Change User's Password
        /// </summary>
        [HttpPost]
        public IHttpActionResult ChangePassword(PasswordRecoveryModel model)
        {
            var result = _repository.Update(model);
            return Ok(result);
        }
    }
}
