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

        public void ShowStatistics()
        {
            var minGrade = double.MaxValue;
            var maxGrade = double.MinValue;
            var average = 0.0;

            foreach (var grade in _grades)
            {
                minGrade = Math.Min(grade, minGrade);
                maxGrade = Math.Max(grade, maxGrade);
                average += grade;
            }

            Console.WriteLine($"Average = {average / _grades.Count:N1}");
            Console.WriteLine($"Lowest grade = {minGrade:N1}");
            Console.WriteLine($"Highest grade = {maxGrade:N1}");
        }
    }
}