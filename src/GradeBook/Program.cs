using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott Pilgrim");

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var userInput = Console.ReadLine();

                if (userInput.Equals("q"))
                {
                    break;
                }

                var grade = double.Parse(userInput);
                book.AddGrade(grade);
            }

            book.ShowStatistics();
        }
    }
}
