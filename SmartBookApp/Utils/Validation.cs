using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Utils
{
    public static class Validation
    {
        // Validates that a field is not null, empty, or whitespace and returns its value
        public static string ValidateField(string value, string fieldName)
        {
            CheckIfNullOrWhiteSpace(value, fieldName);
            return value;
        }

        // Checks if a string is null, empty, or consists only of whitespace
        // Throws an ArgumentException if validation fails
        public static void CheckIfNullOrWhiteSpace(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} cannot be empty.");
            }
        }

    }
}

