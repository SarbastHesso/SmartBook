using SmartBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Tests
{
    // Tests for the Library class
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldAddBook_ByUser()
        {
            // Arrange: Create a new library and some books
            var library = new Library();
            var book_1 = new Book("Title_1", "Author_1", "Category_1");
            var book_2 = new Book("Title_2", "Author_2", "Category_2", "9782365489751");

            // Act: Add the books to the library
            library.AddBook(book_1);
            library.AddBook(book_2);

            // Assert: Make sure the books are present in the library
            Assert.Contains(book_1, library.GetBooks());
            Assert.Contains(book_2, library.GetBooks());
        }

        [Fact]
        public void RemoveBook_ShouldRemoveBook_ByUser()
        {
            //Arrange: Create a library with some books
            var library = new Library();
            var book_1 = new Book("Title_1", "Author_1", "Category_1");
            var book_2 = new Book("Title_2", "Author_2", "Category_2", "9782365489751");
            var book_3 = new Book("Title_3", "Author_3", "Category_3", "9782365489562");
            library.AddBook(book_1);
            library.AddBook(book_2);
            library.AddBook(book_3);

            //Act: Remove books using title and ISBN
            library.RemoveBook("Title_1", "title");
            library.RemoveBook("9782365489751", "isbn");

            //Assert: Make sure the removed books are no longer in the library
            Assert.DoesNotContain(book_1, library.GetBooks());
            Assert.DoesNotContain(book_2, library.GetBooks());
        }
    }
}
