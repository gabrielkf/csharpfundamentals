using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void SetNameFromPointerValue()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        public void SetName(Book book, string name)
        {
            book.Name = name;
        }


        [Fact]
        public void PassValueToMethodIsDefault()
        {
            var book1 = GetBook("Book 1");
            GetBookAndSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        public void GetBookAndSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void PassReference()
        {
            var book1 = GetBook("Book 1");
            GetBookRefAndSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        public void GetBookRefAndSetName(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void OutPassesByValue()
        {
            // var x = GetInt();
            SetInt(out var x);

            Assert.Equal(42, x);
        }

        private void SetInt(out int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Gabriel";
            var upperCase = MakeUpperCase(name);

            Assert.Equal("Gabriel", name);
            Assert.Equal("GABRIEL", upperCase);
        }

        private string MakeUpperCase(string str)
        {
            return str.ToUpper();
        }
    }
}