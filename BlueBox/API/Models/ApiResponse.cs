using System.Collections.Generic;

namespace API.Models
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        public string Message { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = GetDefaultMessageForStatusCode(statusCode);
            Errors = statusCode == 200 || statusCode == 201 ? new List<string>() : new List<string> { message ?? GetDefaultMessageForStatusCode(statusCode) };
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Resource added",
                400 => "Bad Request",
                401 => "You are unauthorized to perform this request",
                403 => "You do not have permission to access this request",
                404 => "Resource not found",
                409 => "Resource already exist",
                500 => "An unhandled error occurred",
                _ => null,
            };
        }
    }
}
