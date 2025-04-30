using SmartBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Tests
{
    public class BookTests
    {
        [Fact]
        public void Constructor_GenerateISBN_WhenNotProvided()
        {
            //Arrange
            var book = new Book("Title", "Author", "Category");

            //Act

            //Assert
            Assert.False(string.IsNullOrWhiteSpace(book.ISBN));
            Assert.StartsWith("978", book.ISBN);
        }

        [Fact]
        public void Constructor_ISBNIsValid_WhenUserProvide()
        {
            // Arrange
            var book = new Book("Title", "Author", "Category", "9782351487965");

            // Act

            // Assert
            Assert.Equal("9782351487965", book.ISBN);
        }
    }
}
