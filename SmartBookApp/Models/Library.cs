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

        //Method to add a new book to the books list
        public void AddBook(Book book)
        {
            //Check if the book we want to add is null
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "The book cannot be null.");
            }

            //Check if a book with the same ISBN already exists
            if (books.Any(b => b.ISBN == book.ISBN))
            {
                throw new InvalidOperationException("A book with the same ISBN already exists.");
            }

            books.Add(book);
        }

        //Remove a book
        public void RemoveBook(string searchTerm, string searchField)
        {
            //Check if book title we trying to remove is null or empty
            Validation.CheckIfNullOrWhiteSpace(searchTerm, nameof(searchTerm));
            Validation.CheckIfNullOrWhiteSpace(searchField, nameof(searchField));

            Book bookToRemove = null;

            switch (searchField.ToLower())
            {
                case "title":
                    //Remove book based on Title
                    bookToRemove = books.FirstOrDefault(b => b.Title.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)); 
                    break;
                case "isbn":
                    //Remove book based on ISBN
                    bookToRemove = books.FirstOrDefault(b => b.ISBN.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)); 
                    break;
                default:
                    throw new ArgumentException("Invalid search field. Please use 'title' or 'isbn'.");
                    break;
            }

            if (!books.Remove(bookToRemove))
            {
                throw new InvalidOperationException("No book found with the provided " + searchField);
            }

        }


        // Returns a read-only list of books to prevent modifications from outside the class
        public IReadOnlyList<Book> GetBooks()
        {
            return books.AsReadOnly();
        }


        // A method to search books by title, author, ISBN, or category
        public List<Book> SearchBooks(string searchTerm, string searchField)
        {

            // Validate that searchTerm and searchField are not null or whitespace
            Validation.CheckIfNullOrWhiteSpace(searchTerm, nameof(searchTerm));
            Validation.CheckIfNullOrWhiteSpace(searchField, nameof(searchField));

            List<Book> searchResult = new List<Book>();

            // We use where to filte and it will returns IEnumerble list, contain to comprision, StringComparison.OrdinalIgnoreCase to ignore the letters case, ToList to conver the collection to list
            switch (searchField.ToLower())
            {
                case "title":
                    searchResult = books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;

                case "author":
                    searchResult = books.Where(b => b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;

                case "isbn":
                    //Because the ISBN is always unique, we find the book and added to the list we are returning
                    Book bookByIsbn = books.FirstOrDefault(b => b.ISBN.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
                    if (bookByIsbn != null)
                    {
                        searchResult.Add(bookByIsbn);
                    }
                    break;

                case "category":
                    searchResult = books.Where(b => b.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;

                default:
                    throw new ArgumentException("Invalid search keyword, please use title, author, isbn or category");

            }

            return searchResult;
        }


    }
}
