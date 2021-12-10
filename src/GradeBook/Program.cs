using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Scott Pilgrim's Grades");
            // IBook book = new DiskBook("Scott Pilgrim's Grades");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            var stats = book.GetStatistics();

            if (stats.Count > 0)
            {
                Console.WriteLine($"\n{book.Name} has {stats.Count} grades");
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

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var userInput = Console.ReadLine();

                if (userInput.Equals("q"))
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(userInput);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade added\n");
        }
    }
}
