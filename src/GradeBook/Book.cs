using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        private List<double> _grades;
        private string _name;

        public Book(string name)
        {
            _name = name;
            _grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            _grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Low = double.MaxValue;
            statistics.High = double.MinValue;
            statistics.Average = 0.0;

            foreach (var grade in _grades)
            {
                statistics.Low = Math.Min(grade, statistics.Low);
                statistics.High = Math.Max(grade, statistics.High);
                statistics.Average += grade;
            }

            statistics.Average /= _grades.Count;

            return statistics;
        }

        public void ShowStatistics()
        {
            var stats = this.GetStatistics();

            Console.WriteLine($"Average = {stats.Average / _grades.Count:N1}");
            Console.WriteLine($"Lowest grade = {stats.Low:N1}");
            Console.WriteLine($"Highest grade = {stats.High:N1}");
        }
    }
}