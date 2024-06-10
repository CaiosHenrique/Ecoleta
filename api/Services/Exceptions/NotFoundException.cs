using System.Net;

namespace api.Services.Exceptions
{
    public class NotFoundException : BaseException
    {

        public NotFoundException(string message) :
            base
                (
                 "HSO-002", // código identificador de erros
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                null,
                DateTimeOffset.UtcNow,
                null
                )
        { }
                
    }
}