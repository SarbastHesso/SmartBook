using SmartBookApp.Models;
using SmartBookApp.Utils;
using SmartBookApp.Services;
using System.Text;

namespace SmartBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Library loadedLibrary = LibraryJsonStorage.LoadLibrary();
            LibraryApp app = new LibraryApp(loadedLibrary);
            app.RunApp();


        }
    }
}
