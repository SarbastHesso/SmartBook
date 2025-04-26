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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ISBN { get; set; }
        public bool IsLoaned { get; set; }


        public Book(string title, string author, string category, string? isbn = null) 
        {
            //check if Title, Author, ISBN, Category is not empty or whitespace using ValidateField method from Validation file
            Title = Validation.ValidateField(title, nameof(Title));
            Author = Validation.ValidateField(author, nameof(Author));
            Category = Validation.ValidateField(category, nameof(Category));
            // Check if the user provided an ISBN. If not, generate a random valid ISBN.
            ISBN = string.IsNullOrWhiteSpace(isbn) ? GenerateISBN() : Validation.ValidateField(isbn, nameof(ISBN));

            //Id = (int)(DateTime.Now.Ticks % int.MaxValue); // Ticks to change Date to number but it returns a long 64 so we use % int.MaxValue to change it to int 32
            Id = GenerateId();
            IsLoaned = false; // default value, when we add a new book is not loaned
        }

        // Method to generate Id, 
        // Ticks to change Date to number(long 64) and  % int.MaxValue to change long 64 to int 32
        public static int GenerateId()
        {
            return (int)(DateTime.Now.Ticks % int.MaxValue);
        }

        //Method to generate ISBN
        // It will generate a random number with 13 digits and always start with 978 and that how a real ISBN looks
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

        public override string ToString()
        {
            return $"{Title} by {Author} | ISBN: {ISBN} | Category: {Category} | {(IsLoaned ? "Loaned out" : "Available")} | ID: {Id}";
        }

    }
}
