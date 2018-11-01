using Moq;
using Schwartz.Movie.Core.ApplicationServices;
using Schwartz.Movie.Core.ApplicationServices.Implementations;
using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Schwartz.Movie.Test.Core.ApplicationServices.Implementations
{
    public class ReviewServiceTest
    {
        /// <summary>
        /// Creates a new Moq of the IReviewRepository, setting up expected returns on public calls
        /// </summary>
        /// <returns></returns>
        private static Mock<IReviewRepository> CreateNewMoqRepository()
        {
            var repository = new Mock<IReviewRepository>();
            repository.Setup(r => r.GetAllReviews())
                .Returns(SampleRatings);
            for (var i = 0; i < 9; i++)
            {
                var n = i + 1;
                repository.Setup(r => r.GetReviewsByMovie(n)).Returns(SampleRatings().Where(f => f.Movie == n).ToList);
                repository.Setup(r => r.GetReviewsByReviewer(n)).Returns(SampleRatings().Where(f => f.Reviewer == n).ToList);
            }

            repository.Setup(
                    r => r.GetReviewsByReviewer(It.IsNotIn(1, 2, 3, 4, 5, 6, 7, 8, 9)))
                .Returns(new List<Rating>());
            repository.Setup(
                    r => r.GetReviewsByMovie(It.IsNotIn(1, 2, 3, 4, 5, 6, 7, 8, 9)))
                .Returns(new List<Rating>());

            return repository;
        }

        /// <summary>
        /// A list containing 73 ratings.
        /// Reviewers range from 1 to 9.
        /// Movies range from 1 to 9.
        /// Grades range from 1 to 5.
        /// Dates range from (Year 2005, Month 9, Day 1) to (Year 2006, Month 5, Day 7)
        /// </summary>
        /// <returns></returns>
        private static List<Rating> SampleRatings()
        {
            return new List<Rating>()
            {
                new Rating() {Reviewer = 1, Movie = 1, Grade = 3, Date = new DateTime(2005, 9, 1)},
                new Rating() {Reviewer = 3, Movie = 1, Grade = 2, Date = new DateTime(2005, 9, 2)},
                new Rating() {Reviewer = 4, Movie = 1, Grade = 1, Date = new DateTime(2005, 9, 3)},
                new Rating() {Reviewer = 5, Movie = 1, Grade = 3, Date = new DateTime(2005, 9, 5)},
                new Rating() {Reviewer = 6, Movie = 1, Grade = 3, Date = new DateTime(2005, 9, 5)},
                new Rating() {Reviewer = 7, Movie = 1, Grade = 3, Date = new DateTime(2005, 9, 6)},
                new Rating() {Reviewer = 8, Movie = 1, Grade = 4, Date = new DateTime(2005, 9, 7)},
                new Rating() {Reviewer = 9, Movie = 1, Grade = 2, Date = new DateTime(2005, 9, 8)},
                new Rating() {Reviewer = 1, Movie = 2, Grade = 1, Date = new DateTime(2005, 10, 1)},
                new Rating() {Reviewer = 2, Movie = 2, Grade = 1, Date = new DateTime(2005, 10, 1)},
                new Rating() {Reviewer = 3, Movie = 2, Grade = 5, Date = new DateTime(2005, 10, 2)},
                new Rating() {Reviewer = 4, Movie = 2, Grade = 4, Date = new DateTime(2005, 10, 3)},
                new Rating() {Reviewer = 5, Movie = 2, Grade = 3, Date = new DateTime(2005, 10, 5)},
                new Rating() {Reviewer = 6, Movie = 2, Grade = 4, Date = new DateTime(2005, 10, 5)},
                new Rating() {Reviewer = 7, Movie = 2, Grade = 2, Date = new DateTime(2005, 10, 6)},
                new Rating() {Reviewer = 8, Movie = 2, Grade = 1, Date = new DateTime(2005, 10, 7)},
                new Rating() {Reviewer = 9, Movie = 2, Grade = 1, Date = new DateTime(2005, 10, 8)},
                new Rating() {Reviewer = 1, Movie = 3, Grade = 4, Date = new DateTime(2005, 11, 1)},
                new Rating() {Reviewer = 2, Movie = 3, Grade = 2, Date = new DateTime(2005, 11, 1)},
                new Rating() {Reviewer = 4, Movie = 3, Grade = 5, Date = new DateTime(2005, 11, 3)},
                new Rating() {Reviewer = 5, Movie = 3, Grade = 1, Date = new DateTime(2005, 11, 5)},
                new Rating() {Reviewer = 6, Movie = 3, Grade = 4, Date = new DateTime(2005, 11, 5)},
                new Rating() {Reviewer = 7, Movie = 3, Grade = 4, Date = new DateTime(2005, 11, 6)},
                new Rating() {Reviewer = 8, Movie = 3, Grade = 1, Date = new DateTime(2005, 11, 7)},
                new Rating() {Reviewer = 9, Movie = 3, Grade = 2, Date = new DateTime(2005, 11, 8)},
                new Rating() {Reviewer = 1, Movie = 4, Grade = 2, Date = new DateTime(2005, 12, 1)},
                new Rating() {Reviewer = 2, Movie = 4, Grade = 1, Date = new DateTime(2005, 12, 1)},
                new Rating() {Reviewer = 3, Movie = 4, Grade = 1, Date = new DateTime(2005, 12, 2)},
                new Rating() {Reviewer = 5, Movie = 4, Grade = 5, Date = new DateTime(2005, 12, 5)},
                new Rating() {Reviewer = 6, Movie = 4, Grade = 4, Date = new DateTime(2005, 12, 5)},
                new Rating() {Reviewer = 7, Movie = 4, Grade = 4, Date = new DateTime(2005, 12, 6)},
                new Rating() {Reviewer = 8, Movie = 4, Grade = 5, Date = new DateTime(2005, 12, 7)},
                new Rating() {Reviewer = 9, Movie = 4, Grade = 5, Date = new DateTime(2005, 12, 8)},
                new Rating() {Reviewer = 1, Movie = 5, Grade = 3, Date = new DateTime(2006, 1, 1)},
                new Rating() {Reviewer = 2, Movie = 5, Grade = 5, Date = new DateTime(2006, 1, 1)},
                new Rating() {Reviewer = 3, Movie = 5, Grade = 3, Date = new DateTime(2006, 1, 2)},
                new Rating() {Reviewer = 4, Movie = 5, Grade = 5, Date = new DateTime(2006, 1, 3)},
                new Rating() {Reviewer = 6, Movie = 5, Grade = 3, Date = new DateTime(2006, 1, 5)},
                new Rating() {Reviewer = 7, Movie = 5, Grade = 3, Date = new DateTime(2006, 1, 6)},
                new Rating() {Reviewer = 8, Movie = 5, Grade = 4, Date = new DateTime(2006, 1, 7)},
                new Rating() {Reviewer = 9, Movie = 5, Grade = 4, Date = new DateTime(2006, 1, 8)},
                new Rating() {Reviewer = 1, Movie = 6, Grade = 2, Date = new DateTime(2006, 2, 1)},
                new Rating() {Reviewer = 2, Movie = 6, Grade = 2, Date = new DateTime(2006, 2, 1)},
                new Rating() {Reviewer = 3, Movie = 6, Grade = 2, Date = new DateTime(2006, 2, 2)},
                new Rating() {Reviewer = 4, Movie = 6, Grade = 1, Date = new DateTime(2006, 2, 3)},
                new Rating() {Reviewer = 5, Movie = 6, Grade = 1, Date = new DateTime(2006, 2, 5)},
                new Rating() {Reviewer = 7, Movie = 6, Grade = 3, Date = new DateTime(2006, 2, 6)},
                new Rating() {Reviewer = 8, Movie = 6, Grade = 1, Date = new DateTime(2006, 2, 7)},
                new Rating() {Reviewer = 9, Movie = 6, Grade = 2, Date = new DateTime(2006, 2, 8)},
                new Rating() {Reviewer = 1, Movie = 7, Grade = 4, Date = new DateTime(2006, 3, 1)},
                new Rating() {Reviewer = 2, Movie = 7, Grade = 3, Date = new DateTime(2006, 3, 1)},
                new Rating() {Reviewer = 3, Movie = 7, Grade = 4, Date = new DateTime(2006, 3, 2)},
                new Rating() {Reviewer = 4, Movie = 7, Grade = 1, Date = new DateTime(2006, 3, 3)},
                new Rating() {Reviewer = 5, Movie = 7, Grade = 3, Date = new DateTime(2006, 3, 5)},
                new Rating() {Reviewer = 6, Movie = 7, Grade = 3, Date = new DateTime(2006, 3, 5)},
                new Rating() {Reviewer = 8, Movie = 7, Grade = 1, Date = new DateTime(2006, 3, 7)},
                new Rating() {Reviewer = 9, Movie = 7, Grade = 1, Date = new DateTime(2006, 3, 8)},
                new Rating() {Reviewer = 1, Movie = 8, Grade = 5, Date = new DateTime(2006, 4, 1)},
                new Rating() {Reviewer = 2, Movie = 8, Grade = 3, Date = new DateTime(2006, 4, 1)},
                new Rating() {Reviewer = 3, Movie = 8, Grade = 1, Date = new DateTime(2006, 4, 2)},
                new Rating() {Reviewer = 4, Movie = 8, Grade = 3, Date = new DateTime(2006, 4, 3)},
                new Rating() {Reviewer = 5, Movie = 8, Grade = 2, Date = new DateTime(2006, 4, 5)},
                new Rating() {Reviewer = 6, Movie = 8, Grade = 4, Date = new DateTime(2006, 4, 5)},
                new Rating() {Reviewer = 7, Movie = 8, Grade = 2, Date = new DateTime(2006, 4, 6)},
                new Rating() {Reviewer = 9, Movie = 8, Grade = 3, Date = new DateTime(2006, 4, 8)},
                new Rating() {Reviewer = 1, Movie = 9, Grade = 3, Date = new DateTime(2006, 5, 1)},
                new Rating() {Reviewer = 2, Movie = 9, Grade = 3, Date = new DateTime(2006, 5, 1)},
                new Rating() {Reviewer = 3, Movie = 9, Grade = 3, Date = new DateTime(2006, 5, 2)},
                new Rating() {Reviewer = 4, Movie = 9, Grade = 5, Date = new DateTime(2006, 5, 3)},
                new Rating() {Reviewer = 5, Movie = 9, Grade = 3, Date = new DateTime(2006, 5, 5)},
                new Rating() {Reviewer = 6, Movie = 9, Grade = 3, Date = new DateTime(2006, 5, 5)},
                new Rating() {Reviewer = 7, Movie = 9, Grade = 3, Date = new DateTime(2006, 5, 6)},
                new Rating() {Reviewer = 8, Movie = 9, Grade = 4, Date = new DateTime(2006, 5, 7)},
            };
        }

        /// <summary>
        /// The numbers in the table below were found by manually counting the sample data.
        /// Require recounting and updating if the existing range of reviewers is altered in any way
        /// </summary>
        /// <param name="reviewer"></param>
        /// <param name="grade"></param>
        /// <param name="expectedAmount"></param>
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 3, 3)]
        [InlineData(1, 4, 2)]
        [InlineData(1, 5, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(2, 2, 2)]
        [InlineData(2, 3, 3)]
        [InlineData(2, 4, 0)]
        [InlineData(2, 5, 1)]
        [InlineData(3, 1, 2)]
        [InlineData(3, 2, 2)]
        [InlineData(3, 3, 2)]
        [InlineData(3, 4, 1)]
        [InlineData(3, 5, 1)]
        [InlineData(4, 1, 3)]
        [InlineData(4, 2, 0)]
        [InlineData(4, 3, 1)]
        [InlineData(4, 4, 1)]
        [InlineData(4, 5, 3)]
        [InlineData(5, 1, 2)]
        [InlineData(5, 2, 1)]
        [InlineData(5, 3, 4)]
        [InlineData(5, 4, 0)]
        [InlineData(5, 5, 1)]
        [InlineData(6, 1, 0)]
        [InlineData(6, 2, 0)]
        [InlineData(6, 3, 4)]
        [InlineData(6, 4, 4)]
        [InlineData(6, 5, 0)]
        [InlineData(7, 1, 0)]
        [InlineData(7, 2, 2)]
        [InlineData(7, 3, 4)]
        [InlineData(7, 4, 2)]
        [InlineData(7, 5, 0)]
        [InlineData(8, 1, 4)]
        [InlineData(8, 2, 0)]
        [InlineData(8, 3, 0)]
        [InlineData(8, 4, 3)]
        [InlineData(8, 5, 1)]
        [InlineData(9, 1, 2)]
        [InlineData(9, 2, 3)]
        [InlineData(9, 3, 1)]
        [InlineData(9, 4, 1)]
        [InlineData(9, 5, 1)]
        private void GetAmountOfReviewsWithGradeByReviewer_TestDataFiltering_ExpectsSuccess(
            int reviewer, int grade, int expectedAmount)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var actualAmount = service.GetAmountOfReviewsWithGradeByReviewer(reviewer, grade);

            Assert.Equal(expectedAmount, actualAmount);
        }

        [Theory]
        [InlineData(10, 1)]
        [InlineData(11, 2)]
        [InlineData(0, 3)]
        [InlineData(-5, 4)]
        [InlineData(int.MaxValue, 5)]
        private void GetAmountOfReviewsWithGradeByReviewer_ReviewerIdNotFound_ExpectsZero(
            int reviewer, int grade)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var actualAmount = service.GetAmountOfReviewsWithGradeByReviewer(reviewer, grade);

            Assert.Equal(0, actualAmount);
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(6)]
        [InlineData(10)]
        private void GetAmountOfReviewsWithGradeByReviewer_GradeOutOfRange_ExpectsException(int grade)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => service.GetAmountOfReviewsWithGradeByReviewer(1, grade));
        }

        /// <summary>
        /// Basic Test to make sure the Moq object has been sat up correctly.
        /// This test should be altered to reflect changes in the Moq setup
        /// </summary>
        [Fact]
        private void TestClassSetup()
        {
            var repository = CreateNewMoqRepository();
            //IReviewService service = new ReviewService(repo.Object);

            var all = repository.Object.GetAllReviews().Count();
            var movies = repository.Object.GetReviewsByMovie(1).Count();
            var reviewers = repository.Object.GetReviewsByReviewer(1).Count();

            // 73 ratings in total
            Assert.Equal(73, all);

            // 8 reviews of movie with id 1
            Assert.Equal(8, movies);

            // 9 reviews by reviewer 1
            Assert.Equal(9, reviewers);
        }

        [Theory]
        [InlineData(1, 9)]
        [InlineData(2, 8)]
        [InlineData(3, 8)]
        [InlineData(4, 8)]
        [InlineData(5, 8)]
        [InlineData(6, 8)]
        [InlineData(7, 8)]
        private void GetReviewCountByReviewer(int reviewer, int countExpected)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var countActual = service.ReviewsByReviewerCount(reviewer);

            Assert.Equal(countExpected, countActual);
        }

        [Fact]
        private void GetTopReviewersTest()
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var reviewerActual = service.GetTopReviewers()[0];
            Assert.Equal(1, reviewerActual);
        }

        [Theory]
        [InlineData(1, 2.6)]
        [InlineData(2, 2.4)]
        [InlineData(3, 2.9)]
        [InlineData(4, 3.4)]
        [InlineData(5, 3.8)]
        [InlineData(6, 1.8)]
        [InlineData(7, 2.5)]
        [InlineData(8, 2.9)]
        [InlineData(9, 3.4)]
        private void GetAverageMovieRating_ValidData_ExpectsSuccess(int movie, double rating)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var movieRating = service.GetAverageMovieRating(movie);

            Assert.Equal(rating, movieRating);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10)]
        private void GetAverageMovieRating_InvalidMovieId_ExpectsZero(int id)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var rating = service.GetAverageMovieRating(id);

            Assert.Equal(0, rating);
        }

        [Fact]
        private void GetTopNMovies()
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var topMovies = service.GetTopMovies(4);
            var actualTop = new List<int> { 9, 4, 3, 8 };

            topMovies.ForEach(m => Assert.Contains(m, actualTop));
        }

        [Fact]
        private void GetTop5Movies()
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var topMovies = service.GetTopFiveMovies();
            var actualTop = new List<int> { 9, 4, 3, 8, 1 };

            topMovies.ForEach(m => Assert.Contains(m, actualTop));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(15)]
        private void GetListOfReviewersByMovie_InvalidData_ExpectsEmptyList(int id)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var reviewers = service.GetListOfReviewersByMovie(id);

            Assert.NotNull(reviewers);
            Assert.Empty(reviewers);
        }

        [Theory]
        [InlineData(1, 8)]
        [InlineData(2, 9)]
        [InlineData(3, 8)]
        [InlineData(4, 8)]
        [InlineData(5, 8)]
        [InlineData(6, 8)]
        [InlineData(7, 8)]
        [InlineData(8, 8)]
        [InlineData(9, 8)]
        private void GetListOfReviewersByMovie_ValidData_ExpectsSuccess(int id, int expected)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var reviewers = service.GetListOfReviewersByMovie(id);

            Assert.NotEmpty(reviewers);
            Assert.Equal(expected, reviewers.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        [InlineData(10)]
        private void GetAverageRatingByReviewer_InvalidData_ExpectsNegativeOne(int id)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var rating = service.GetAverageRatingByReviewer(id);

            Assert.Equal(-1, rating);
        }

        [Theory]
        [InlineData(1, 3.0)]
        [InlineData(2, 2.5)]
        [InlineData(3, 2.6)]
        [InlineData(4, 3.1)]
        [InlineData(5, 2.6)]
        [InlineData(6, 3.5)]
        [InlineData(7, 3.0)]
        [InlineData(8, 2.6)]
        [InlineData(9, 2.5)]
        private void GetAverageRatingByReviewer_ValidData_ExpectsSuccess(int id, double expected)
        {
            var repository = CreateNewMoqRepository();
            IReviewService service = new ReviewService(repository.Object);

            var rating = service.GetAverageRatingByReviewer(id);

            Assert.Equal(expected, rating);
        }
    }
}