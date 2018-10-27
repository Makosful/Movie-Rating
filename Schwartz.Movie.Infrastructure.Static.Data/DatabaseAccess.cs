using Microsoft.EntityFrameworkCore;
using Schwartz.Movie.Core.Entities;

namespace Schwartz.Movie.Infrastructure.Static.Data
{
    public static class DatabaseAccess
    {
        public static MovieRatingContext Context { get; } = new MovieRatingContext();

        public class MovieRatingContext : DbContext
        {
            public DbSet<Rating> Ratings { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MovieRatingDatabase");
            }
        }
    }
}