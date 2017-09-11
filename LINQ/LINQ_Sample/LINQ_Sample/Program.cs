using System;

namespace Task
{
    internal class Program
    {
        private static void Main()
        {
            var sample = new LinqSamples();

            sample.Linq001(100000);
            sample.Linq002();
            sample.Linq003(1000);
            sample.Linq004();
            sample.Linq005();
            sample.Linq006();
            sample.Linq007();

            Console.ReadLine();
        }
    }
}