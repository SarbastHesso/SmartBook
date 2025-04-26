using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookApp.Utils
{
    public static class Validation
    {
        // static method to validate if field is null or empty
        public static string ValidateField(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName} cannot be embty.");
            }
            return value;
        }

    }
}
