using System;

namespace Schwartz.Movie.Core.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Reviewer: {Reviewer}, Movie: {Movie}, Grade: {Grade}, Date: {Date}";
        }
    }
}