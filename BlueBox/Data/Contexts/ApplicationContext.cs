using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
    public class ApplicationContext : IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
            .HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Iron Man",
                    Year = 2008,
                    Slug = "iron-man",
                    Description = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                    Trending = true,
                    CreatedDate = DateTime.Now
                },
               new Movie
               {
                   Id = 2,
                   Name = "Iron Man 2",
                   Year = 2010,
                   Slug = "iron-man2",
                   Description = "With the world now aware of his identity as Iron Man, Tony Stark must contend with both his declining health and a vengeful mad man with ties to his father's legacy.",
                   Trending = true,
                   CreatedDate = DateTime.Now
               },
               new Movie
               {
                   Id = 3,
                   Name = "Iron Man 3",
                   Year = 2010,
                   Slug = "iron-man3",
                   Description = "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.",
                   Trending = true,
                   CreatedDate = DateTime.Now
               }
            );

            builder.Entity<MovieImage>().HasData(
                        new MovieImage
                        {
                            Id = 1,
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/1/1e/Iron_Man_Official_Poster.jpg",
                            IsBanner = true,
                            CreatedDate = DateTime.Now,
                            MovieId = 1
                        },
                        new MovieImage
                        {
                            Id = 2,
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/9/9d/Tumblr_l1iotoYo541qbn8c7.jpg",
                            IsBanner = false,
                            CreatedDate = DateTime.Now,
                            MovieId = 1
                        },
                        new MovieImage
                        {
                            Id = 3,
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/c/cb/Iron_Man_2_Official_Poster.jpg",
                            IsBanner = true,
                            CreatedDate = DateTime.Now,
                            MovieId = 2
                        },
                        new MovieImage
                        {
                            Id = 4,
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/89/2010_iron_man_2_052.jpg",
                            IsBanner = false,
                            CreatedDate = DateTime.Now,
                            MovieId = 2
                        },
                        new MovieImage
                        {
                            Id = 5,
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/5/55/Iron_Man_3_IMAX_poster.jpg",
                            IsBanner = true,
                            CreatedDate = DateTime.Now,
                            MovieId = 3
                        },
                        new MovieImage
                        {
                            Id = 6,
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/a/a3/Iron_flag.png",
                            IsBanner = false,
                            CreatedDate = DateTime.Now,
                            MovieId = 3
                        }
                );
            base.OnModelCreating(builder);
        }

    }
}
