using System;
using DataConvertion;

namespace ExceptionsHandling
{
    public class StringToIntHandler
    {
        public void InvokeStringToInt()
        {
            var elements = DataInitializer.DataInitializer.StringToIntDataInitializer();
            var stringToInt = new StringToInt();

            Console.WriteLine("String to Int32 - Bit conversion");

            foreach (var item in elements)
            {
                try
                {
                    Console.WriteLine("Input: {0}, Converted Value : {1} \n", item, stringToInt.ConvertStringToInt(item));
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input :{0}, Error Message: {1} \n", item, e.Message);
                }
            }
        }
    }
}