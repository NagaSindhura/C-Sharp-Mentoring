using System;
using System.IO;
using System.Xml.Serialization;

namespace Module5.Serialization
{
    public abstract class PersistentSettingsBase<T>
    {
        public static T XmlDeserialize(string xmlString)
        {
            if (string.IsNullOrEmpty(xmlString))
            {
                Console.WriteLine("Empty xml format");
            }

            var serializer = new XmlSerializer(typeof(T));

            using (var myStream = new StringReader(xmlString))
            {
                try
                {
                    var obj = (T)serializer.Deserialize(myStream);
                    return obj;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to create object from xml string", ex);
                }
            }
        }
    }
}