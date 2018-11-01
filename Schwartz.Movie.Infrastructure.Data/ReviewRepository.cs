using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Core.Entities;
using Schwartz.Movie.Infrastructure.Static.Data;
using System.Collections.Generic;
using System.Linq;
using static Schwartz.Movie.Infrastructure.Static.Data.DatabaseAccess;

namespace Schwartz.Movie.Infrastructure.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private MovieRatingContext Context { get; }

        public ReviewRepository()
        {
            Context = DatabaseAccess.Context;

            // Add all the ratings to the database on application startup
            IFileReader fileReader = new JsonFileReader();
            var ratings = fileReader.ReadFile("ratings.test.json");
            foreach (var rating in ratings)
            {
                Context.Ratings.Add(rating);
            }

            Context.SaveChanges();
        }

        public List<Rating> GetAllReviews()
        {
            return Context.Ratings.ToList();
        }

        public List<Rating> GetReviewsByReviewer(int reviewerId)
        {
            return Context.Ratings.Where(r => r.Reviewer == reviewerId).ToList();
        }

        public List<Rating> GetReviewsByMovie(int movieId)
        {
            return Context.Ratings.Where(r => r.Movie == movieId).ToList();
        }
    }
}