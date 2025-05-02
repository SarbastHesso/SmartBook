using SmartBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBookApp.Services
{
    // This class manages the console interface and interaction with the Library
    public class LibraryApp
    {
        private Library library;

        // Default constructor: creates a new, empty library
        public LibraryApp()
        {
            library = new Library();
        }

        // Constructor that accepts a loaded library (e.g., from file)
        public LibraryApp(Library loadedLibrary)
        {
            library = loadedLibrary ?? new Library();
        }

        // Main loop of the application
        public void RunApp()
        {
            bool isAlive = true;

            while (isAlive)
            {
                try
                {
                    ShowMenu();

                    string input = Console.ReadLine();
                    Console.WriteLine();

                    // Validate input
                    if (!int.TryParse(input, out int choice) || choice < 1 || choice > 8)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                        continue;
                    }

                    // Run selected option
                    switch (choice)
                    {
                        case 1:
                            AddBookToLibrary();
                            break;
                        case 2:
                            RemoveBookFromLibrary();
                            break;
                        case 3:
                            DisplayAllBooks();
                            break;
                        case 4:
                            SearchBooksInLibrary();
                            break;
                        case 5:
                            ToggleBookLoanStatus();
                            break;
                        case 6:
                            SaveLibraryToFile();
                            break;
                        case 7:
                            LoadLibraryFromFile();
                            break;
                        case 8:
                            isAlive = false;
                            Console.WriteLine("Exit the app");
                            break;
                        default:
                            Console.WriteLine("Invalid input, try again");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }

        // Displays the main menu
        private void ShowMenu()
        {
            Console.WriteLine("===================== SmartBook Menu =====================");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Remove a book (by title or ISBN)");
            Console.WriteLine("3. List all books (sorted by title)");
            Console.WriteLine("4. Search for a book (title, author, ISBN or category)");
            Console.WriteLine("5. Toggle loan status (borrow or return)");
            Console.WriteLine("6. Save library to file");
            Console.WriteLine("7. Load library from file");
            Console.WriteLine("8. Exit");
            Console.WriteLine("==========================================================");
            Console.Write("Select an option (1-8): ");
        }

        // Add a new book to the library
        public void AddBookToLibrary()
        {
            try
            {
                // Ask for book details
                Console.Write("Enter book title: ");
                string title = Console.ReadLine().Trim();

                Console.Write("Enter author name: ");
                string author = Console.ReadLine().Trim();

                Console.Write("Enter book category: ");
                string category = Console.ReadLine().Trim();

                Console.Write("Enter ISBN (leave empty to auto-generate): ");
                string isbn = Console.ReadLine().Trim();

                // Create the book object
                Book newBook = new Book(title, author, category, isbn);

                // Add book to the library
                library.AddBook(newBook);

                Console.WriteLine("The book has been successfully added to the library.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Remove a book from the library by title or ISBN
        public void RemoveBookFromLibrary()
        {

            try
            {
                Console.Write("Enter 'title' or 'isbn' to search by: ");
                string searchField = Console.ReadLine()?.Trim().ToLower();

                Console.Write("Enter the value to search for: ");
                string searchValue = Console.ReadLine()?.Trim();

                library.RemoveBook(searchValue, searchField);
                Console.WriteLine("Book removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Display all books in the library, sorted by title
        public void DisplayAllBooks()
        {
            try
            {
                var books = library.GetBooks();

                if (books.Count == 0)
                {
                    Console.WriteLine("No books found in the library.");
                }
                else
                {
                    Console.WriteLine("List of all books in the library:");
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while displaying books: {ex.Message}");
            }
        }


        // Search for books by title, author, ISBN, or category
        public void SearchBooksInLibrary()
        {
            try
            {
                Console.Write("Enter search field (title, author, isbn, category): ");
                string searchFieldName = Console.ReadLine().Trim().ToLower();

                Console.Write("Enter search value: ");
                string searchFieldValue = Console.ReadLine().Trim();

                var results = library.SearchBooks(searchFieldValue, searchFieldName);

                if (results.Count == 0)
                {
                    Console.WriteLine("No books found matching the search criteria.");
                }
                else
                {
                    Console.WriteLine("List of all books matching the search criteria:");
                    foreach (var book in results)
                    {
                        Console.WriteLine(book);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Toggle loan status for a book by title
        public void ToggleBookLoanStatus()
        {
            try
            {
                Console.Write("Enter the title of the book to toggle loan status: ");
                string title = Console.ReadLine();

                // Toggle the loan status
                library.ToggleLoanStatus(title);

                Console.WriteLine("The loan status has been successfully toggled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Save the library to a file (implementation not yet done)
        public void SaveLibraryToFile()
        {
            Utils.LibraryJsonStorage.SaveLibrary(library);
        }

        // Load the library from a file (implementation not yet done)
        public void LoadLibraryFromFile()
        {
            library = Utils.LibraryJsonStorage.LoadLibrary();
            DisplayAllBooks();
        }
    }
}
