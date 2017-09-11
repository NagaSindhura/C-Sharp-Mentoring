using System;
using CollectionsAndGenerics.Colors;
using CollectionsAndGenerics.Interfaces;

namespace CollectionsAndGenerics
{
    public class Program
    {
        public static void Main()
        {
            var colorCollection = new CustomCollection<IColor>();
            var green = new Color<Green> { Count = 10 };

            colorCollection.Add(green);
            colorCollection.Add(new Color<Red> { Count = 11 });
            colorCollection.Add(new Color<Blue> { Count = 12 });
            colorCollection.Add(new Color<Green> { Count = 13 });
            colorCollection.Add(new Color<Red> { Count = 14 });
            colorCollection.Add(new Color<Blue> { Count = 15 });

            Console.WriteLine("green, red, blue colors added to collection");
            Console.WriteLine("---Before Deletion---");

            foreach (var color in colorCollection)
            {
                Console.WriteLine(color.Name);
            }

            colorCollection.Remove(green);

            Console.WriteLine("green color object removed from the collection");
            Console.WriteLine("---After Deletion---");

            foreach (var color in colorCollection)
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine("Current Collection {0}", colorCollection.Current.Name);
            Console.WriteLine("Collection count {0}", colorCollection.Count);

            colorCollection.Add(new Color<Green> { Count = 14 });

            Console.WriteLine("green color added to collection");

            colorCollection.Add(new Color<Green> { Count = 15 });

            Console.WriteLine("Updated count {0}", colorCollection.Count);
            Console.ReadLine();
        }
    }
}