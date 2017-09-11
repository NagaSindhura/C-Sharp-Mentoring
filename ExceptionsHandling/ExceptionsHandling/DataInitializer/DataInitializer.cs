using System;
using System.Collections.Generic;

namespace ExceptionsHandling.DataInitializer
{
    public class DataInitializer
    {
        public static Stack<string> StackDataInitializer()
        {
            return new Stack<string>(new[]
                                         {
                                             "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                             "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                                             "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
                                             "31", "32", "33", "34", "35", "36", "37", "38", "39", "40",
                                             "41", "42", "43", "44", "45", "46", "47", "48", "49", "50",
                                             "one",
                                             "51", "52", "53", "55", "55", "56", "57", "58", "59", "60",
                                             "61", "62", "63", "64", "65", "66", "67", "68", "69", "70",
                                             "71", "72", "73", "74", "75", "76", "77", "78", "79", "80",
                                             "81", "82", "83", "84", "85", "86", "87", "88", "89", "90",
                                             "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"
                                         });
        }

        public static IList<string> StringToIntDataInitializer()
        {
            return new List<string>
                       {
                           "1",
                           "1.5",
                           null,
                           "zxcvbbnnmmadsfgjhkllpiouytreqqdgjkk",
                           "123456",
                           "123456789123456789",
                           string.Empty,
                           "-32768", 
                           "32767", 
                           "32769",
                           "-2147483648", // min 32bit value
                           "2147483647", // Max 32bit Value
                           "-3147483647",
                           "3147483647"
                       };
        }
    }
}