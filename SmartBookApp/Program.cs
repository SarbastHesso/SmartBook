using SmartBookApp.Models;
using System.Text;

namespace SmartBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book("My Life", "Sarbast Hesso", "jh213587", "Drama");
            Console.WriteLine(myBook);

            Console.ReadLine();
        }
    }
}
