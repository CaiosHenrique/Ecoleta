using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using api.Services.Http;

namespace api.Services.Exceptions
{
    public class BaseException : Exception
    {
        private HttpErrorResponse HttpResponse { get; set; }
        private HttpStatusCode StatusCode { get; set; }

        public BaseException(string errorCode, string message, HttpStatusCode httpStatusCode, int statusCode, string uriPath, DateTimeOffset timestamp, Exception? ex) : base(message, ex)
        {
            StatusCode = httpStatusCode;
            HttpResponse = new HttpErrorResponse(errorCode, message, statusCode, uriPath, timestamp);
        }

        public IActionResult GetResponse()
        {
            return new ContentResult
            {
                StatusCode = (int)StatusCode,
                Content = JsonConvert.SerializeObject(HttpResponse, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }),
            };
        }
    }
}