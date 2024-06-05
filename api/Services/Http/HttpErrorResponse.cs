namespace api.Services.Http
{
    public class HttpErrorResponse
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string UriPath { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public HttpErrorResponse(string errorCode, string message, int statusCode, string uriPath, DateTimeOffset timestamp)
        {
            ErrorCode = errorCode;
            Message = message;
            StatusCode = statusCode;
            UriPath = uriPath;
            Timestamp = timestamp;
        }
    }
}