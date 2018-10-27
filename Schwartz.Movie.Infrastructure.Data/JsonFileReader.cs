using Newtonsoft.Json;
using Schwartz.Movie.Core.DomainServices;
using Schwartz.Movie.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;

// ReSharper disable PossibleInvalidOperationException

namespace Schwartz.Movie.Infrastructure.Data
{
    public class JsonFileReader : IFileReader
    {
        /// <summary>
        /// Interface implementation
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public IEnumerable<Rating> ReadFile(string filePath)
        {
            var ratings = new List<Rating>();

            using (var streamReader = new StreamReader(filePath))
            using (var reader = new JsonTextReader(streamReader))
            {
                try
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType != JsonToken.StartObject) continue;
                        var rating = CreateRating(reader);

                        ratings.Add(rating);
                    }
                }
                catch (JsonReaderException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return ratings;
        }

        /// <summary>
        /// Creates a new Rating object from the JsonReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Rating CreateRating(JsonReader reader)
        {
            var rating = new Rating();
            for (var i = 0; i < 4; i++)
            {
                reader.Read();
                switch (reader.Value)
                {
                    case "Reviewer":
                        rating.Reviewer = (int)reader.ReadAsInt32();
                        break;

                    case "Movie":
                        rating.Movie = (int)reader.ReadAsInt32();
                        break;

                    case "Grade":
                        rating.Grade = (float)reader.ReadAsDecimal();
                        break;

                    case "Date":
                        rating.Date = (DateTime)reader.ReadAsDateTime();
                        break;

                    default:
                        throw new InvalidDataException("no such token: " + reader.Value);
                }
            }

            return rating;
        }
    }
}