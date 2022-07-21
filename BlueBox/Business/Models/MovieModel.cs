using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Models
{
    public class MovieModel
    {
        public MovieModel()
        {
            MovieImages = new List<MovieImageModel>();
        }
        public string Slug { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }
        public string Description { get; set; }
        public string BannerImage { get { return MovieImages?.FirstOrDefault(x => x.IsBanner)?.ImageUrl; } }
        public List<MovieImageModel> MovieImages { get; set; }
    }
}
