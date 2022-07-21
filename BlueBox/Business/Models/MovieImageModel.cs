using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class MovieImageModel
    {
        public int MovieId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBanner { get; set; }
    }
}
