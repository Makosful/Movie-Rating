﻿using Schwartz.Movie.Core.DomainServices;
using System.Collections.Generic;

namespace Schwartz.Movie.Core.ApplicationServices.Implementations
{
    public class ReviewService : IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        private IReviewRepository ReviewRepository { get; }

        public int GetAmountOfReviewsWithGradeByReviewer(int reviewerId, int grade)
        {
            throw new System.NotImplementedException();
        }

        public double GetAverageMovieRating(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public double GetAverageRatingByReviewer(int reviewerId)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetListOfReviewersByMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public int GetMovieGradeCount(int movieId, int grade)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMoviesByReviewer(int reviewerId)
        {
            throw new System.NotImplementedException();
        }

        public int GetReviewerCountByMovie(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopFiveMovies()
        {
            return GetTopMovies(5);
        }

        public List<int> GetTopMovies(int count)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopReviewers(int count = 1)
        {
            throw new System.NotImplementedException();
        }

        public int ReviewsByReviewerCount(int reviewerId)
        {
            throw new System.NotImplementedException();
        }
    }
}