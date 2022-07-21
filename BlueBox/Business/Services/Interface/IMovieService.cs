using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interface
{
    public interface IMovieService
    {
        Task<IList<MovieModel>>  GetTrendingMoviesAsync();
    }
}
