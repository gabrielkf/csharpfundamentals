using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        private List<double> _grades;
        const string _category = "Math";

        public InMemoryBook(string name) : base(name)
        {
            _grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.Low = double.MaxValue;
            stats.High = double.MinValue;
            stats.Average = 0.0;

            foreach (var grade in _grades)
            {
                stats.Low = Math.Min(grade, stats.Low);
                stats.High = Math.Max(grade, stats.High);
                stats.Average += grade / _grades.Count;
            }

            switch (stats.Average)
            {
                case var d when d >= 90.0:
                    stats.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    stats.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    stats.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    stats.Letter = 'D';
                    break;

                case var d when d >= 50.0:
                    stats.Letter = 'E';
                    break;

                default:
                    stats.Letter = 'F';
                    break;
            }

            return stats;
        }

        public override void ShowStatistics()
        {
            if (_grades.Count > 0)
            {
                var stats = this.GetStatistics();

                Console.WriteLine("");
                Console.WriteLine($"There are {_grades.Count} grades");
                Console.WriteLine($"Average = {stats.Average:N1}");
                Console.WriteLine($"Lowest grade = {stats.Low:N1}");
                Console.WriteLine($"Highest grade = {stats.High:N1}");
                Console.WriteLine($"The letter grade is {stats.Letter}");
            }
            else
            {
                Console.WriteLine("This grade book is empty");
            }
        }
    }
}