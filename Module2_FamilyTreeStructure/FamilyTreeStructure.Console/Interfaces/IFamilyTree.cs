using FamilyTreeStructure.Entity;
using System.Collections.Generic;

namespace FamilyTreeStructure.Interfaces
{
    public interface IFamilyTree
    {
        void ShowTree(Person person, int nesting);

        IList<Person> SearchByName(string name);
    }
}