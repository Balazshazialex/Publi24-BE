using System;
using System.ComponentModel.DataAnnotations;

namespace Publi24.Validators
{
    public class CustomIsinValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string isin = value as string;
            if (!String.IsNullOrEmpty(isin) && Char.IsLetter(isin[0]) && Char.IsLetter(isin[1]))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult
                    ("Isin must start with 2 letters");
            }
        }
    }
}
