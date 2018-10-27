using Schwartz.Movie.Core.Entities;
using System.Collections.Generic;

namespace Schwartz.Movie.Core.DomainServices
{
    public interface IReviewRepository
    {
        List<Rating> GetAllReviews();

        List<Rating> GetReviewsByReviewer(int reviewerId);

        List<Rating> GetReviewsByMovie(int movieId);
    }
}