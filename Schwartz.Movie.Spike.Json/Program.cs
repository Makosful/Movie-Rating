using Newtonsoft.Json;
using Schwartz.Movie.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

// ReSharper disable PossibleInvalidOperationException

namespace Schwartz.Movie.Spike.Json
{
    internal static class Program
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            ReadBrokenJson();
        }

        private static void ReadBrokenJson()
        {
            var ratings = new List<Rating>();

            var stopwatch = Stopwatch.StartNew();

            using (StreamReader streamReader = new StreamReader(@"ratings.json"))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                try
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var rating = CreateRating(reader);

                            ratings.Add(rating);
                        }
                    }
                }
                catch (JsonReaderException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Time: {stopwatch.Elapsed.Seconds}");
            Console.WriteLine($"Ratings: {ratings.Count}");

            ratings.Clear();

            Console.ReadKey();
        }

        private static Rating CreateRating(JsonTextReader reader)
        {
            Rating rating = new Rating();
            for (int i = 0; i < 4; i++)
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
                        rating.Grade = (int)reader.ReadAsInt32();
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