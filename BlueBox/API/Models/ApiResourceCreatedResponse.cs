using Microsoft.AspNetCore.Http;

namespace API.Models
{
    public class ApiResourceCreatedResponse : ApiResponse
    {
        public object Result { get; }

        public ApiResourceCreatedResponse(object result) : base(StatusCodes.Status201Created)
        {
            Result = result;
        }
    }
}
