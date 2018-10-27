using Moq;
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
        /// Creates a new
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

            return repository;
        }

        [Fact]
        public void TestClassSetup()
        {
            var repo = CreateNewMoqRepository();
            //var service = new ReviewService(repo.Object);

            var all = repo.Object.GetAllReviews().Count();
            var movies = repo.Object.GetReviewsByMovie(1).Count();
            var reviewers = repo.Object.GetReviewsByReviewer(1).Count();

            // 73 ratings in total
            Assert.Equal(73, all);

            // 8 reviews of movie with id 1
            Assert.Equal(8, movies);

            // 9 reviews by reviewer 1
            Assert.Equal(9, reviewers);
        }
    }
}