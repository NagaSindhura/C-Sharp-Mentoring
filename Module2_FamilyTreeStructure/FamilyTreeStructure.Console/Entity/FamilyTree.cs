using System;
using System.Collections.Generic;
using FamilyTreeStructure.Interfaces;
using ListOfPersons = System.Collections.Generic.List<FamilyTreeStructure.Entity.Person>;
using System.Text;
using FamilyTreeStructure.Initialization;

namespace FamilyTreeStructure.Entity
{
    public class FamilyTree : IFamilyTree
    {
        public FamilyTree()
        {
            Persons = new ListOfPersons();
            Person = FamilyDataInitialization.RootPerson();
        }

        public DateTime DateOfCreation { get; set; }

        public ListOfPersons Persons { get; set; }

        public Person Person { get; set; }

        public IList<Person> SearchByName(string name)
        {
            var persons = new ListOfPersons();

            if (Person == null || Persons == null)
            {
                return null;
            }

            GetFamilyMembers(Person);

            foreach (var person in Persons)
            {
                if (person.ToString().ToUpper().Contains(name.ToUpper()))
                {
                    persons.Add(person);
                }
            }

            return persons;
        }

        public void GetFamilyMembers(Person person)
        {
            if (person == null)
            {
                return;
            }

            Persons.Add(person);

            if (person.Father == null)
            {
                return;
            }

            GetFamilyMembers(person.Father);

            if (person.Mother == null)
            {
                return;
            }

            GetFamilyMembers(person.Mother);
        }

        public decimal TotalIncome(ListOfPersons family)
        {
            decimal income  = 0;

            if (family == null)
            {
                return income;
            }

            foreach (var member in family)
            {
                income = income + (member.Income ?? 0);
            }

            return income;
        }

        public void ShowTree(Person person, int nesting)
        {
            if (person == null)
            {
                return;
            }

            Console.WriteLine("{0} - {1}", new string('\t', nesting), person);

            if (person.Father == null)
            {
                return;
            }

            ShowTree(person.Father, ++nesting);
            --nesting;

            if (person.Mother == null)
            {
                return;
            }

            ShowTree(person.Mother, ++nesting);
            --nesting;
        }

        public string GetFamily(IList<Person> persons)
        {
            var family = new StringBuilder();
            foreach (var person in persons)
            {
                family.Append($"{person.FirstName} {person.LastName},");
            }

            return family.ToString().Trim(',');
        }
    }
}