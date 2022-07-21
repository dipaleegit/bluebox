using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace API.Models
{
    public class ApiBadRequestResponse : ApiResponse
    {

        public ApiBadRequestResponse(ModelStateDictionary modelState)
            : base(StatusCodes.Status400BadRequest)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}
