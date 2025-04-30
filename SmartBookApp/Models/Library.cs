using SmartBookApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBookApp.Models
{
    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book), "The book cannot be null.");

            if (Books.Any(b => b.ISBN == book.ISBN))
                throw new InvalidOperationException("A book with the same ISBN already exists.");

            Books.Add(book);
        }

        public void RemoveBook(string searchFieldValue, string searchFieldName)
        {
            Validation.CheckIfNullOrWhiteSpace(searchFieldValue, nameof(searchFieldValue));
            Validation.CheckIfNullOrWhiteSpace(searchFieldName, nameof(searchFieldName));

            Book bookToRemove = null;

            switch (searchFieldName.ToLower())
            {
                case "title":
                    bookToRemove = Books.FirstOrDefault(b => b.Title.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "isbn":
                    bookToRemove = Books.FirstOrDefault(b => b.ISBN.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    throw new ArgumentException("Invalid search field. Please use 'title' or 'isbn'.");
            }

            if (!Books.Remove(bookToRemove))
            {
                throw new InvalidOperationException($"No book found with the provided {searchFieldName}: {searchFieldValue}");
            }
        }

        public IReadOnlyList<Book> GetBooks()
        {
            var sortedBooks = Books.OrderBy(b => b.Title).ToList();
            return sortedBooks.AsReadOnly();
        }

        public List<Book> SearchBooks(string searchFieldValue, string searchFieldName)
        {
            Validation.CheckIfNullOrWhiteSpace(searchFieldValue, nameof(searchFieldValue));
            Validation.CheckIfNullOrWhiteSpace(searchFieldName, nameof(searchFieldName));

            IEnumerable<Book> filteredBooks;

            switch (searchFieldName.ToLower())
            {
                case "title":
                    filteredBooks = Books.Where(b => b.Title.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "author":
                    filteredBooks = Books.Where(b => b.Author.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "isbn":
                    filteredBooks = Books.Where(b => b.ISBN.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                case "category":
                    filteredBooks = Books.Where(b => b.Category.Contains(searchFieldValue, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    throw new ArgumentException("Invalid search keyword, please use title, author, isbn or category.");
            }

            return filteredBooks.ToList();
        }

        public void ToggleLoanStatus(string title)
        {
            Validation.CheckIfNullOrWhiteSpace(title, nameof(title));

            Book foundBook = Books.FirstOrDefault(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (foundBook == null)
            {
                throw new InvalidOperationException($"No book found with the title: {title}");
            }

            foundBook.IsLoaned = !foundBook.IsLoaned;
        }
    }
}
