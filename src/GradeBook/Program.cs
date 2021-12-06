using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott Pilgrim");
            book.AddGrade(89.1);
            book.AddGrade(79.1);
            book.AddGrade(85.6);
            book.ShowStatistics();
        }
    }
}
