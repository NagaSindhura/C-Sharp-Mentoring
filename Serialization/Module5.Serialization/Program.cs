using System;
using System.IO;
using System.Web.Script.Serialization;

namespace Module5.Serialization
{
    public class Program
    {
        public static void Main()
        {
            var _path = "../../input/books.xml";
            var reader = new StreamReader(_path);
            var s = reader.ReadToEnd();
            reader.Close();

            Console.WriteLine("----- XML Deserialize Started ------");
            var deserializedCatalog1 = Catalog.XmlDeserialize(s);
            Console.WriteLine("----- XML Deserialize Completed ------");

            var xmlSeralizer = new JavaScriptSerializer();

            var str = xmlSeralizer.Serialize(deserializedCatalog1);
            Console.WriteLine(str);
            Console.WriteLine("----- Javascript serialization completed on the Deserialize Object ------");
            Console.ReadLine();
        }
    }
}