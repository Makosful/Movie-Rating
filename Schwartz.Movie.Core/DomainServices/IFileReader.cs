using Schwartz.Movie.Core.Entities;
using System.Collections.Generic;

namespace Schwartz.Movie.Core.DomainServices
{
    public interface IFileReader
    {
        IEnumerable<Rating> ReadFile(string filePath);
    }
}