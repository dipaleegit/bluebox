using Microsoft.AspNetCore.Http;

namespace API.Models
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result) : base(StatusCodes.Status200OK)
        {
            Result = result;
        }
    }
}
