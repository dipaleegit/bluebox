using AutoMapper;
using Business.Models;
using Business.Services.Interface;
using Data.Models;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly IBaseRepository<Movie> _movieRepo;
        private readonly IMapper _mapper;
        public MovieService(IBaseRepository<Movie> movieRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
        }

        public async Task<IList<MovieModel>> GetTrendingMoviesAsync()
        {
            var movies = await _movieRepo.FindAllAsync(x => x.Trending, x => x.MovieImages).ToListAsync();
            return _mapper.Map<List<MovieModel>>(movies);
        }
    }
}
