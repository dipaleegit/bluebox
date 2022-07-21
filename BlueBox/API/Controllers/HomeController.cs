using API.Infrastructure.ActionFilters;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(ApiValidationFilterAttribute))]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok(new ApiOkResponse("Ok"));
        }
    }
}
