using System;
using System.ComponentModel.DataAnnotations;

namespace VoorbeeldExamen.Models
{
    internal class ProjValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string toCheck = (string)value;

            if (toCheck.Length == 9 && toCheck.StartsWith("PROJ_"))
                return true;

            ErrorMessage = "Foute schrijfwijze projectnaam";

            return false;
        }
    }
}