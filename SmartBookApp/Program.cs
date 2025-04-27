using SmartBookApp.Models;
using System.Text;

namespace SmartBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book_1 = new Book("Book one", "Sarbast Hesso", "Romance", "9782314987683");
            Book book_2 = new Book("Book Tow", "Rosel Hesso", "Mystery");
            Book book_3 = new Book("Book Three", "Naya Hesso", "Horror");
            Book book_4 = new Book("Book Four", "Roni Hesso", "Fantasy");

            Library myLibrary = new Library();
            myLibrary.AddBook(book_1);
            myLibrary.AddBook(book_2);
            myLibrary.AddBook(book_3);
            myLibrary.AddBook(book_4);

            IReadOnlyList<Book> allBooks = myLibrary.GetBooks();

            foreach (Book b in allBooks)
            {
                Console.WriteLine(b);
            }

            Console.WriteLine("----------------------------------------");
            List<Book> searchedBooks = myLibrary.SearchBooks("Sarbast", "author");
            List<Book> searchedBooks2 = myLibrary.SearchBooks(book_3.ISBN, "isbn");

            foreach (Book b in searchedBooks)
            {
                Console.WriteLine(b);
            }

            if (searchedBooks2.Count > 0)
            {
                foreach (Book b in searchedBooks2)
                {
                    Console.WriteLine(b);
                }
            }


            Console.WriteLine("----------------------------------------");
            myLibrary.RemoveBook("Book Four", "title");
            myLibrary.RemoveBook(book_3.ISBN, "isbn");
            foreach (Book b in allBooks)
            {
                Console.WriteLine(b);
            }

            Console.ReadLine();
        }
    }
}
