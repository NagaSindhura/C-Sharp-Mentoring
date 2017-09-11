using System;
using FamilyTreeStructure.Entity;

namespace FamilyTreeStructure
{
    public class Program
    {
        public static void Main()
        {
            var familyTree = new FamilyTree();

            Console.WriteLine("!!! Your Family Tree !!!");
            Console.WriteLine(new string('-', 10));

            familyTree.ShowTree(familyTree.Person, 0);

            Console.WriteLine(new string('-', 10));

            Console.WriteLine("see search results by name for several persons");
            Console.WriteLine("Please enter the name that you wants to search");

            string searchString;

            if ((searchString = Console.ReadLine()) != null)
            {
                var persons = familyTree.SearchByName(searchString);

                if (persons != null)
                {
                    foreach (var personDisplay in persons)
                    {
                        Console.WriteLine(personDisplay);
                    }
                }
                else
                {
                    Console.WriteLine("no results found!!");
                }
            }
            else
            {
                Console.WriteLine("something WellKnownClientTypeEntry wrong!!");
            }

            Console.WriteLine(new string('-', 10));

            Console.WriteLine("your Total Income of your Family : {0}", familyTree.TotalIncome(familyTree.Persons));
            Console.WriteLine(new string('-', 10));

            Console.WriteLine("your Family : {0}", familyTree.GetFamily(familyTree.Persons));

            Console.WriteLine(new string('-', 10));
            Console.WriteLine("Happyend!!");
            Console.ReadLine();
        }
    }
}