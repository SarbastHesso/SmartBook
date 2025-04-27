using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Utils
{
    public static class Validation
    {
        // static method to validate if field is not null or empty and returns a value
        public static string ValidateField(string value, string fieldName)
        {
            CheckIfNullOrWhiteSpace(value, fieldName);
            return value;
        }

        // static method to validate if a string is null or empty 
        public static void CheckIfNullOrWhiteSpace(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} cannot be empty.");
            }
        }

    }
}
