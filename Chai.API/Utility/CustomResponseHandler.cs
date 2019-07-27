using Chai.API.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Chai.API.Utility
{
    public class CustomResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (IsSwagger(request))
                return await base.SendAsync(request, cancellationToken);

            var response = await base.SendAsync(request, cancellationToken);
            
            try
            {
                return GenerateResponse(request, response);
            }
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        private HttpResponseMessage GenerateResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            string errorMessage = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            object responseContent = null;
            ResponseMetadata responseMetadata;

            //if (!IsResponseValid(response))
            //{
            //    statusCode = HttpStatusCode.BadRequest;
            //    responseMetadata = CreateMetaResponse(statusCode, errorMessage);
            //    return request.CreateResponse(statusCode, responseMetadata);
            //}
            if (response.TryGetContentValue(out responseContent) && !response.IsSuccessStatusCode)
            {
                HttpError httpError = responseContent as HttpError;
                if (httpError != null)
                {
                    errorMessage = httpError.Message;
                    statusCode = response.StatusCode;
                }
            }
            else
            {
                errorMessage = response.ReasonPhrase;
                statusCode = response.StatusCode;
            }

            responseMetadata = CreateMetaResponse(statusCode, errorMessage, responseContent);

            var result = request.CreateResponse(response.StatusCode, responseMetadata);
            return result;
        }
        private bool IsResponseValid(HttpResponseMessage response)
        {
            if ((response != null) && (response.StatusCode == HttpStatusCode.OK))
                return true;
            return false;
        }

        private bool IsResponseContentEmpty(object content)
        {
            if (content == null)
                return true;
            return false;
        }

        private bool IsSwagger(HttpRequestMessage request)
        {
            return request.RequestUri.PathAndQuery.StartsWith("/swagger");
        }

        private ResponseMetadata CreateMetaResponse(HttpStatusCode statusCode, string errorMessage=null, object responseContent=null)
        {
            ResponseMetadata responseMetadata = new ResponseMetadata();
            responseMetadata.StatusCode = statusCode;
            responseMetadata.Content = responseContent;
            responseMetadata.ErrorMessage = errorMessage;
            return responseMetadata;
        }
    }

    internal class ResponseMetadata
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Content { get; set; }
    }
}