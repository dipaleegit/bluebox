using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public short Year { get; set; }
        public string Description { get; set; }
        public bool Trending { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ICollection<MovieImage> MovieImages { get; set; }
    }
}
