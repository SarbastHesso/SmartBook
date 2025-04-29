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
            string json = JsonSerializer.Serialize(library);
            File.WriteAllText(filePath, json);
        }

        public static Library LoadLibrary()
        {
            if (!File.Exists(filePath))
            {
                return new Library();
            }
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Library>(json);
        }
    }
}
