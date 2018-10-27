﻿using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Core.Entities;
using Schwartz.Movie.Infrastructure.Static.Data;
using System.Collections.Generic;

namespace Schwartz.Movie.Infrastructure.Data
{
    public class ReviewRepository : IReviewRepository
    {
        public DatabaseAccess.MovieRatingContext Context { get; set; }

        public ReviewRepository()
        {
            // Add all the ratings to the database on application startup
            IFileReader fileReader = new JsonFileReader();
            var ratings = fileReader.ReadFile("ratings.json");
            foreach (var rating in ratings)
            {
                Context.Ratings.Add(rating);
            }

            Context.SaveChanges();
        }

        public List<Rating> GetAllReviews()
        {
            throw new System.NotImplementedException();
        }

        public List<Rating> GetReviewsByReviewer(int reviewerId)
        {
            throw new System.NotImplementedException();
        }

        public List<Rating> GetReviewsByMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }
    }
}