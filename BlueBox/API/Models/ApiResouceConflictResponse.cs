using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ApiResouceConflictResponse : ApiResponse
    {
        public ApiResouceConflictResponse(string message) : base(StatusCodes.Status409Conflict, message)
        {
        }
    }
}
