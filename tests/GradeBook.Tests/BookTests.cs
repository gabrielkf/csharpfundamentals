using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CalculateStatistics()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var actualStats = book.GetStatistics();

            // assert
            Assert.Equal(85.6, actualStats.Average, 1);
            Assert.Equal(90.5, actualStats.High, 1);
            Assert.Equal(77.3, actualStats.Low, 1);
            Assert.Equal('B', actualStats.Letter);
        }
    }
}
