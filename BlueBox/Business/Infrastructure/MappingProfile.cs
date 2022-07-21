using AutoMapper;
using Business.Models;
using Data.Models;

namespace Business.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieModel, Movie>().ReverseMap();
            CreateMap<MovieImage, MovieImageModel>();
        }
    }
}
