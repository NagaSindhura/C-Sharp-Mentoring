using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Script.Serialization;

namespace Module5.Serialization
{
    [Serializable]
    [XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]
    public class Catalog : PersistentSettingsBase<Catalog>
    {
        [XmlIgnore]
        [ScriptIgnore]
        public DateTime CreatedDate { get; set; }

        [XmlAttribute("date")]
        public string CreatedDateValue
        {
            get { return this.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.CreatedDate = DateTime.Parse(value); }
        }

        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
}