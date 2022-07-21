using API.Models;
using Business.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("trending")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Trending()
        {
            var movies = await _movieService.GetTrendingMoviesAsync();
            return Ok(new ApiOkResponse(movies));
        }
    }
}
