using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Infrastructure.Data;
using Xunit;

namespace Schwartz.Movie.Test.Infrastructure.Data
{
    public class ReviewRepositoryTest
    {
        //[Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void GetReviewsByReviewer_InvalidReviewerId_ExpectsEmptyList(int id)
        {
            IReviewRepository repository = new ReviewRepository();
            var ratings = repository.GetReviewsByReviewer(id);

            Assert.NotNull(ratings);
            Assert.Empty(ratings);
        }

        //[Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void GetReviewsByMovie_InvalidMovieId_ExpectsEmptyLists(int id)
        {
            IReviewRepository repository = new ReviewRepository();
            var ratings = repository.GetReviewsByMovie(id);

            Assert.NotNull(ratings);
            Assert.Empty(ratings);
        }
    }
}