using System.Collections.Generic;

namespace Schwartz.Movie.Core.ApplicationServices
{
    public interface IReviewService
    {
        /// <summary>
        /// On input N and G, how many times has reviewer N given a movie grade G?
        /// </summary>
        int GetAmountOfReviewsWithGradeByReviewer(int reviewerId, int grade);

        /// <summary>
        /// On input N, what is the average rate the movie N had received?
        /// </summary>
        double GetAverageMovieRating(int movieId);

        /// <summary>
        /// On input N, what is the average rate that reviewer N had given?
        /// </summary>
        double GetAverageRatingByReviewer(int reviewerId);

        /// <summary>
        /// On input N, what are the reviewers that have reviewed movie N?
        /// The list should be sorted decreasing by rate first, and date secondly.
        /// </summary>
        List<int> GetListOfReviewersByMovie(int movieId);

        /// <summary>
        /// On input N and G, how many times had movie N received grade G?
        /// </summary>
        int GetMovieGradeCount(int movieId, int grade);

        /// <summary>
        /// On input N, what are the movies that reviewer N has reviewed?
        /// The list should be sorted decreasing by rate first, and date secondly.
        /// </summary>
        List<int> GetMoviesByReviewer(int reviewerId);

        /// <summary>
        /// On input N, how many have reviewed movie N?
        /// </summary>
        int GetReviewerCountByMovie(int movieId);

        /// <summary>
        /// What is the id(s) of the movie(s) with the highest number of top rates (5)?
        /// </summary>
        List<int> GetTopFiveMovies();

        /// <summary>
        /// On input N, what is top N of movies?
        /// The score of a movie is its average rate.
        /// </summary>
        List<int> GetTopMovies(int count);

        /// <summary>
        /// What reviewer(s) had done most reviews?
        /// </summary>
        List<int> GetTopReviewers(int count = 1);

        /// <summary>
        /// On input N, what are the number of reviews from reviewer N?
        /// </summary>
        /// <param name="reviewerId"></param>
        int ReviewsByReviewerCount(int reviewerId);
    }
}