using System;

namespace ExceptionsHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stringToIntHandler = new StringToIntHandler();
            stringToIntHandler.InvokeStringToInt();

            Console.WriteLine(new string('-', 50));

            var dataTransfer = new DataTransfer();
            dataTransfer.StackTransfer();

            Console.ReadLine();
        }
    }
}