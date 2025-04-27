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
        public void RemoveBook(string searchTerm, string searchField)
        {
            // Validate input
            Validation.CheckIfNullOrWhiteSpace(searchTerm, nameof(searchTerm));
            Validation.CheckIfNullOrWhiteSpace(searchField, nameof(searchField));

            Book bookToRemove = null;

            switch (searchField.ToLower())
            {
                case "title":
                    // Find book by title
                    bookToRemove = books.FirstOrDefault(b => b.Title.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
                    break;
                case "isbn":
                    // Find book by ISBN
                    bookToRemove = books.FirstOrDefault(b => b.ISBN.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    throw new ArgumentException("Invalid search field. Please use 'title' or 'isbn'.");
            }

            // If no book found, throw exception
            if (bookToRemove == null)
            {
                throw new InvalidOperationException($"No book found with the provided {searchField}: {searchTerm}");
            }

            // Try to remove the book
            if (!books.Remove(bookToRemove))
            {
                throw new InvalidOperationException("Failed to remove the book from the library.");
            }
        }

        // Returns a read-only list of all books
        public IReadOnlyList<Book> GetBooks()
        {
            return books.AsReadOnly();
        }

        // Searches for books by title, author, ISBN, or category
        public List<Book> SearchBooks(string searchTerm, string searchField)
        {
            // Validate input
            Validation.CheckIfNullOrWhiteSpace(searchTerm, nameof(searchTerm));
            Validation.CheckIfNullOrWhiteSpace(searchField, nameof(searchField));

            IEnumerable<Book> filteredBooks;

            // Filter books based on search field
            switch (searchField.ToLower())
            {
                case "title":
                    filteredBooks = books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                    break;
                case "author":
                    filteredBooks = books.Where(b => b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                    break;
                case "isbn":
                    filteredBooks = books.Where(b => b.ISBN.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
                    break;
                case "category":
                    filteredBooks = books.Where(b => b.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
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
                throw new InvalidOperationException("No book found with the provided title.");
            }

            // Toggle the loan status
            foundBook.IsLoaned = !foundBook.IsLoaned;
        }
    }
}

