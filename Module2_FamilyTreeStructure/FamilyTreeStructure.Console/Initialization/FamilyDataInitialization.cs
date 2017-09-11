using System;
using FamilyTreeStructure.Entity;

namespace FamilyTreeStructure.Initialization
{
    public class FamilyDataInitialization
    {
        public static Person RootPerson()
        {
            var person = new Person();

            Console.WriteLine("enter First name");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("enter Last name");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("Enter Gender as MALE/FEMALE format");

            var gender = Console.ReadLine();

            if (!string.IsNullOrEmpty(gender) && Enum.IsDefined(typeof(Gender), gender.ToUpper()))
            {
                person.Gender = (Gender)Enum.Parse(typeof(Gender), gender.ToUpper());
            }

            Console.WriteLine("enter Date Of Birth(mm/dd/yyyy) format");

            var dobInput = Console.ReadLine();
            DateTime dob;

            if (DateTime.TryParse(dobInput, out dob))
            {
                person.DateOfBirth = dob;
            }

            Console.WriteLine("enter Date Of Death(mm/dd/yyyy) format (if Applicable)");
            var dodInput = Console.ReadLine();

            DateTime dod;

            if (dodInput != null && DateTime.TryParse(dodInput, out dod))
            {
                person.DateOfBirth = dod;
            }

            Console.WriteLine("Please enter yout Income");
            var incomeInput = Console.ReadLine();
            var income = 0;

            if (int.TryParse(incomeInput, out income))
            {
                var validationResults = person.Validate();

                foreach (var validation in validationResults)
                {
                    Console.WriteLine(validation);
                }
                //TODO: validationResults is never null
                if (validationResults != null)
                {
                    person.Income = income;
                }
            }

            person.AddParent(
                   new Person
                   {
                       FirstName = "Subbarao",
                       LastName = "Pulivarthy",
                       DateOfBirth = DateTime.Parse("1958-10-10"),
                       Gender = Gender.MALE,
                       Income = 5000
                   });

            person.AddParent(
                   new Person
                   {
                       FirstName = "RamaDevi",
                       LastName = "Pulivarthy",
                       DateOfBirth = DateTime.Parse("1963-07-09"),
                       Gender = Gender.FEMALE,
                       Income = 500
                   });

            person.Father.AddParent(
                   new Person
                   {
                       FirstName = "Nagaiah",
                       LastName = "Pulivarthy",
                       DateOfBirth = DateTime.Parse("1908-05-10"),
                       Gender = Gender.MALE,
                   });

            person.Father.AddParent(
                    new Person
                    {
                        FirstName = "Rosamma",
                        LastName = "Pulivarthy",
                        DateOfBirth = DateTime.Parse("1915-04-05"),
                        Gender = Gender.FEMALE,
                        Income = 300
                    });

            person.Mother.AddParent(
                    new Person
                    {
                        FirstName = "Venkateswarlu",
                        LastName = "Pulivarthy",
                        DateOfBirth = DateTime.Parse("1958-10-10"),
                        Gender = Gender.MALE,
                        Income = 300
                    });

            person.Mother.AddParent(
                new Person
                {
                    FirstName = "punnamma",
                    LastName = "Pulivarthy",
                    DateOfBirth = DateTime.Parse("2006-07-09"),
                    Gender = Gender.FEMALE,
                });

            return person;
        }
    }
}