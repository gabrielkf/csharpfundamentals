using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Scott Pilgrim's Grades");
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);
            book.ShowStatistics();
        }

        private static void EnterGrades(InMemoryBook book)
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
