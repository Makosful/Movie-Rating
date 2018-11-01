using Schwartz.Movie.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schwartz.Movie.Core.ApplicationServices.Implementations
{
    public class ReviewService : IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private IReviewRepository ReviewRepository { get; }

        public int GetAmountOfReviewsWithGradeByReviewer(int reviewerId, int grade)
        {
            if (grade < 1 || grade > 5)
                throw new ArgumentOutOfRangeException(nameof(grade), "A review can only give a move a rating between 1 and 5");

            var ratings = ReviewRepository.GetReviewsByReviewer(reviewerId);
            var enumerable = ratings.Where(r => r.Grade == grade);

            return enumerable.Count();
        }

        public double GetAverageMovieRating(int movieId)
        {
            var ratings = ReviewRepository.GetReviewsByMovie(movieId);

            if (!ratings.Any()) return 0d;

            double sum = 0;

            foreach (var rating in ratings)
                sum += rating.Grade;

            var avg = sum / ratings.Count;

            return Math.Round(avg, 1);
        }

        public double GetAverageRatingByReviewer(int reviewerId)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetListOfReviewersByMovie(int movieId)
        {
            var reviewers = new List<int>();
            var ratings = ReviewRepository.GetReviewsByMovie(movieId);

            // Assumes a reviewer can only leave one review on a movie
            foreach (var rating in ratings)
            {
                if (!reviewers.Contains(rating.Reviewer))
                {
                    reviewers.Add(rating.Reviewer);
                }
            }

            return reviewers;
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
            return ReviewRepository.GetReviewsByMovie(movieId).Count;
        }

        public List<int> GetTopFiveMovies()
        {
            return GetTopMovies(5);
        }

        public List<int> GetTopMovies(int count)
        {
            var reviews = ReviewRepository.GetAllReviews();
            var movies = new Dictionary<int, double>();
            reviews.ForEach(m =>
            {
                if (!movies.ContainsKey(m.Movie))
                {
                    movies.Add(m.Movie, GetAverageMovieRating(m.Movie));
                }
            });
            var topMovies = new List<int>();
            movies.OrderByDescending(m => m.Value).Take(count).
                                                Select(m =>
                                                {
                                                    topMovies.Add(m.Key);
                                                    return m;
                                                });
            return topMovies;
        }

        public List<int> GetTopReviewers(int count = 1)
        {
            var dictionary = new Dictionary<int, int>();
            ReviewRepository.GetAllReviews().ForEach(r =>
            {
                if (!dictionary.ContainsKey(r.Reviewer))
                {
                    dictionary.Add(r.Reviewer, 1);
                }
                else
                {
                    dictionary[r.Reviewer]++;
                }
            });
            Console.WriteLine(dictionary);
            var maxValue = dictionary.Values.Max();
            return new List<int> { dictionary.FirstOrDefault(k => k.Value == maxValue).Key };
        }

        public int ReviewsByReviewerCount(int reviewerId)
        {
            var reviews = ReviewRepository.GetReviewsByReviewer(reviewerId);
            return reviews.Count();
        }
    }
}