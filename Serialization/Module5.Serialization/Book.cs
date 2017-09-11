using System;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Reflection;

namespace Module5.Serialization
{
    [Serializable]
    public class Book
    {
        [XmlAttribute("id")]
        public string BookId { get; set; }

        [XmlElement("isbn")]
        public string Isbn { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlIgnore]
        [ScriptIgnore]
        public DateTime PublishDate { get; set; }

        [XmlElement("publish_date")]
        public string PublishDateValue
        {
            get { return XmlConvert.ToString(PublishDate, XmlDateTimeSerializationMode.RoundtripKind); }
            set { PublishDate = DateTimeOffset.Parse(value).DateTime; }
        }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlIgnore]
        [ScriptIgnore]
        public DateTime RegisteredDate { get; set; }

        [XmlElement("registration_date")]
        public string RegisteredDateValue
        {
            get { return XmlConvert.ToString(RegisteredDate, XmlDateTimeSerializationMode.RoundtripKind); }
            set { RegisteredDate = DateTimeOffset.Parse(value).DateTime; }
        }

        [XmlIgnore]
        [ScriptIgnore]
        public Genre Genre;

        [XmlElement("genre")]
        public string GenreValue
        {
            get
            {
                return GetEnumDescription(Genre);
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Genre = default(Genre);
                }
                else
                {
                    Genre = (Genre)Enum.Parse(typeof(Genre), value.Replace(" ", string.Empty));
                }
            }
        }

        //to get the enum values with spaces like "Science Fiction"
        public static string GetEnumDescription(Genre value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }
    }
}