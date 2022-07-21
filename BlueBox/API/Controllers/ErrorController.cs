using API.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger _logger;

        public ErrorController(ILogger logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            return StatusCode(statusCode, new ApiResponse(statusCode));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("")]
        public IActionResult Index()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exurl = $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}{exceptionHandlerPathFeature.Path}";
            _logger.Error(exceptionHandlerPathFeature.Error, exurl);
            return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse(StatusCodes.Status500InternalServerError, exceptionHandlerPathFeature.Error.Message));
        }
    }
}
