using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> _grades;
        public string Name;

        public Book(string name)
        {
            Name = name;
            _grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.Low = double.MaxValue;
            stats.High = double.MinValue;
            stats.Average = 0.0;

            foreach (var grade in _grades)
            {
                stats.Low = Math.Min(grade, stats.Low);
                stats.High = Math.Max(grade, stats.High);
                stats.Average += grade;
            }

            stats.Average /= _grades.Count;

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

        public void ShowStatistics()
        {
            var stats = this.GetStatistics();

            Console.WriteLine($"Average = {stats.Average / _grades.Count:N1}");
            Console.WriteLine($"Lowest grade = {stats.Low:N1}");
            Console.WriteLine($"Highest grade = {stats.High:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}