﻿using Chai.API.Utility;
using Newtonsoft.Json;
using System.Web.Http.ExceptionHandling;

namespace Chai.API.ExceptionHandlers
{
    /// <summary>
    /// Global handler to customize the response back to the calling party of your API.
    /// </summary>
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
#if DEBUG
            var content = JsonConvert.SerializeObject(context.Exception);
#else
            var content = @"{ ""message"" : ""Oops, something unexpected went wrong"" }";
#endif
            context.Result = new ErrorContentResult(content, "application/json", context.Request);
        }
    }
}