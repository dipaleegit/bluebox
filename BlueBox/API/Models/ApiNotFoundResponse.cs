using Microsoft.AspNetCore.Http;

namespace API.Models
{
    public class ApiNotFoundResponse : ApiResponse
    {
        public ApiNotFoundResponse(string message) : base(StatusCodes.Status404NotFound, message)
        {
        }
    }
}
