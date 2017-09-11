using System.ComponentModel;
using System.Xml.Serialization;

namespace Module5.Serialization
{
    public enum Genre
    {
        [XmlEnum]
        Computer = 1,

        [XmlEnum]
        Fantasy = 2,

        [XmlEnum]
        Romance = 3,

        [XmlEnum]
        Horror = 4,

        [Description("Science Fiction")]
        [XmlEnum]
        ScienceFiction = 5
    }
}
