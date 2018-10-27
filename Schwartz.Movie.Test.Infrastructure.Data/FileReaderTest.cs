using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Infrastructure.Data;
using System.Linq;
using Xunit;

namespace Schwartz.Movie.Test.Infrastructure.Data
{
    public class FileReaderTest
    {
        private const string PathTest = @"ratings.test.json";

        [Fact]
        public void ReadFile_LoadsFileCorrectly_ExpectsSuccess()
        {
            IFileReader fileReader = new JsonFileReader();
            fileReader.ReadFile(PathTest);
        }

        /// <summary>
        /// Test must be changed to reflect amount of Rating objects in the file tested on
        /// </summary>
        [Fact]
        public void ReadFile_CountLoadedRatings_ExpectsSuccess()
        {
            IFileReader fileReader = new JsonFileReader();
            var ratings = fileReader.ReadFile(PathTest).ToList();

            Assert.NotEmpty(ratings);
            Assert.Equal(10, ratings.Count());
        }
    }
}