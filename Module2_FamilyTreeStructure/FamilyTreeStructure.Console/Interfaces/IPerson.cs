using System.Collections.Generic;
using FamilyTreeStructure.Entity;

namespace FamilyTreeStructure.Interfaces
{
    public interface IPerson
    {
        void AddParent(Person parent);

        void AddChild(Person child);

        void AddChilds(IList<Person> childs);
    }
}