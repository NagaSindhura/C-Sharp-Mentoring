using System;
using FamilyTreeStructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace FamilyTreeStructure.Entity
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public Person Father { get; set; }

        public Person Mother { get; set; }

        public IList<Person> Childs { get; set; }

        [PersonValidation(ErrorMessage = "{0} is invalid.")]
        public decimal? Income { get; set; }

        public override string ToString()
        {
            return $"{FirstName} - {LastName} [Date of birth] :  {DateOfBirth.ToString("MM/dd/yyyy")} {(DateOfDeath.HasValue ? " - [Date of death] : " + DateOfDeath.Value.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) : "")}";
        }

        public void AddParent(Person parent)
        {
            if (parent == null)
            {
                return;
            }

            switch (parent.Gender)
            {
                case Gender.MALE:
                    Father = parent;
                    break;

                case Gender.FEMALE:
                    Mother = parent;
                    break;

                default:
                    Console.WriteLine("please enter valid gender details");
                    break;
            }
        }

        public void AddChild(Person child)
        {
            Childs.Add(child);
        }

        public void AddChilds(IList<Person> childs)
        {
            Childs = childs.ToList();
        }

        public IList<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null);
            var isValid = Validator.TryValidateObject(this, vc, validationResults, true);

            return validationResults;
        }
    }
}