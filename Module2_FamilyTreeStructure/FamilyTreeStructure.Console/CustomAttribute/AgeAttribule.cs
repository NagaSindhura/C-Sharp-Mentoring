
using System;

namespace FamilyTreeStructure.Entity
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultAgeAttribute : Attribute
    {
        public DefaultAgeAttribute(int defaultAge)
        {
            this.DefaultAge = defaultAge;
        }

        public int DefaultAge { get; set;}
    }
}
