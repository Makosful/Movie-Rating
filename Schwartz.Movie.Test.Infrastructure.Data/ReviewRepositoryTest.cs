using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Infrastructure.Data;
using Xunit;

namespace Schwartz.Movie.Test.Infrastructure.Data
{
    public class ReviewRepositoryTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void GetReviewsByReviewer_InvalidReviewerId_ExpectsEmptyList(int id)
        {
            IReviewRepository reviewRepository = new ReviewRepository();
            var list = reviewRepository.GetReviewsByReviewer(id);

            Assert.NotNull(list);
        }
    }
}