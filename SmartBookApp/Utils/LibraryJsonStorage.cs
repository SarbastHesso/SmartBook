using SmartBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartBookApp.Utils
{
    public static class LibraryJsonStorage
    {
        private static readonly string filePath = "library.json";

        public static void SaveLibrary(Library library)
        {
            try
            {
                string json = JsonSerializer.Serialize(library);
                File.WriteAllText(filePath, json);

                Console.WriteLine("Library saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static Library LoadLibrary()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("No saved library found.");
                    return new Library();
                }

                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Library>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading library: {ex.Message}");
                return new Library(); 
            }
        }
    }
}
