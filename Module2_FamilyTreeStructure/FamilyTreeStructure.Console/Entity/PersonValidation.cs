using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FamilyTreeStructure.Entity
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PersonValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;
            var age = DateTime.Now.Year - person.DateOfBirth.Year;

            if (age < 18 || person.DateOfDeath != null)
            {
                return new ValidationResult("Income shoule not be there for majors/died persons.");
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}