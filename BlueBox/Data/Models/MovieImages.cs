using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    [Table("MovieImages")]
    public class MovieImage
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBanner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
