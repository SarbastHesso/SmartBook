using SmartBookApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Models
{
    public class Book
    {
        // Properties of the book
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ISBN { get; set; }
        public bool IsLoaned { get; set; }

        public Book(string title, string author, string category, string? isbn = null)
        {
            // Validate that Title, Author, and Category are not empty or whitespace
            Title = Validation.ValidateField(title, nameof(Title));
            Author = Validation.ValidateField(author, nameof(Author));
            Category = Validation.ValidateField(category, nameof(Category));

            // Validate or generate ISBN if not provided
            ISBN = string.IsNullOrWhiteSpace(isbn) ? GenerateISBN() : Validation.ValidateField(isbn, nameof(ISBN));

            // By default, a new book is available (not loaned)
            IsLoaned = false;
        }


        // Generates a random valid ISBN
        // ISBN will be 13 digits and start with '978' as real ISBN numbers do
        public static string GenerateISBN()
        {
            Random random = new Random();
            StringBuilder isbnBuilder = new StringBuilder("978");
            for (int i = 0; i < 10; i++)
            {
                isbnBuilder.Append(random.Next(0, 10));
            }
            return isbnBuilder.ToString();
        }

        // Overrides ToString to return a readable summary of the book
        public override string ToString()
        {
            return $"{Title} by {Author} | ISBN: {ISBN} | Category: {Category} | {(IsLoaned ? "Loaned out" : "Available")}";
        }
    }
}

