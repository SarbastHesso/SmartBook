using SmartBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Tests
{
    // Tests for the Book class
    public class BookTests
    {
        [Fact]
        public void Constructor_GenerateISBN_WhenNotProvided()
        {
            //Arrange: create a new book without ISBN
            var book = new Book("Title", "Author", "Category");

            //Act

            //Assert
            // Check that the ISBN was generated and is not empty
            Assert.False(string.IsNullOrWhiteSpace(book.ISBN));

            // Check that the generated ISBN starts with "978"
            Assert.StartsWith("978", book.ISBN);
        }

        [Fact]
        public void Constructor_ISBNIsValid_WhenUserProvide()
        {
            // Arrange: Create a new book with a specific ISBN provided
            var book = new Book("Title", "Author", "Category", "9782351487965");

            // Act

            // Assert: Check that the book's ISBN is exactly what was provided
            Assert.Equal("9782351487965", book.ISBN);
        }
    }
}
