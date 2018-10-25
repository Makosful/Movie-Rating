using Microsoft.EntityFrameworkCore;
using Schwartz.Movie.Core.Entities;

namespace Schwartz.Movie.Infrastructure.Static.Data
{
    public class DatabaseAccess
    {
        public static MovieRatingContext Context { get; } = new MovieRatingContext();

        public class MovieRatingContext : DbContext
        {
            public DbSet<Rating> Ratings { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("MovieRatingDatabase");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}