using SmartBookApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Models
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }


        // Adds a new book to the library
        public void AddBook(Book book)
        {
            // Validate that the book is not null
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "The book cannot be null.");
            }

            // Check if a book with the same ISBN already exists
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                throw new InvalidOperationException("A book with the same ISBN already exists.");
            }

            books.Add(book);
        }


        // Removes a book based on title or ISBN
        public void RemoveBook(string searchFieldValue, string searchFieldName)
        {
            // Validate input
            Validation.CheckIfNullOrWhiteSpace(searchFieldValue, nameof(searchFieldValue));
            Validation.CheckIfNullOrWhiteSpace(searchFieldName, nameof(searchFieldName));

            Book bookToRemove = null;

            switch (searchFieldName.ToLower())
            {
                case "title":
                    // Find book by title
                    bookToRemove = books.FirstOrDefault(b => b.Title.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "isbn":
                    // Find book by ISBN
                    bookToRemove = books.FirstOrDefault(b => b.ISBN.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    throw new ArgumentException("Invalid search field. Please use 'title' or 'isbn'.");
            }


            // Try to remove the book (if it exists in the list)
            if (!books.Remove(bookToRemove))
            {
                throw new InvalidOperationException($"No book found with the provided {searchFieldName}: {searchFieldValue}");
            }
        }



        // Returns a read-only list of all books
        public IReadOnlyList<Book> GetBooks()
        {
            return books.AsReadOnly();
        }



        // Searches for books by title, author, ISBN, or category
        public List<Book> SearchBooks(string searchFieldValue, string searchFieldName)
        {
            // Validate input
            Validation.CheckIfNullOrWhiteSpace(searchFieldValue, nameof(searchFieldValue));
            Validation.CheckIfNullOrWhiteSpace(searchFieldName, nameof(searchFieldName));

            IEnumerable<Book> filteredBooks;

            // Filter books based on search field
            switch (searchFieldName.ToLower())
            {
                case "title":
                    filteredBooks = books.Where(b => b.Title.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "author":
                    filteredBooks = books.Where(b => b.Author.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "isbn":
                    filteredBooks = books.Where(b => b.ISBN.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "category":
                    filteredBooks = books.Where(b => b.Category.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    throw new ArgumentException("Invalid search keyword, please use title, author, isbn or category.");
            }

            return filteredBooks.ToList();
        }



        // Toggles the loan status of a book based on title
        public void ToggleLoanStatus(string title)
        {
            // Validate input
            Validation.CheckIfNullOrWhiteSpace(title, nameof(title));

            // Find the book by title
            Book foundBook = books.FirstOrDefault(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (foundBook == null)
            {
                throw new InvalidOperationException($"No book found with the title: {title}");
            }

            // Toggle the loan status
            foundBook.IsLoaned = !foundBook.IsLoaned;
        }
    }
}

