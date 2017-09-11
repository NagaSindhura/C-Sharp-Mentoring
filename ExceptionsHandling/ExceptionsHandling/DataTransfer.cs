using System;
using DataConvertion;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionsHandling
{
    public class DataTransfer
    {
        public Stack<string> DataTransferElements { get; set; }

        private Stack<string> _dataTransferElements;

        public DataTransfer()
        {
            _dataTransferElements = new Stack<string>();
            DataTransferElements = DataInitializer.DataInitializer.StackDataInitializer();
        }

        public void StackTransfer()
        {
            if (DataTransferElements == null)
            {
                Console.WriteLine("Stack is Empty");

                return;
            }

            Console.WriteLine("Before dataTransfer: Elements in Stack");

            foreach (var item in DataTransferElements)
            {
                Console.Write(item + " ");
            }

            try
            {
                var stringToInt = new StringToInt();

                while (DataTransferElements.Count > 0)
                {
                    _dataTransferElements.Push(DataTransferElements.Pop());

                    stringToInt.ConvertStringToInt(_dataTransferElements.Peek());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nException Occured due to : {0} \n", e.Message);

                while (_dataTransferElements.Count() > 0)
                {
                    DataTransferElements.Push(_dataTransferElements.Pop());
                }

                Console.WriteLine("Data retained to initial state of the application");
            }
            finally
            {
                _dataTransferElements = null;
            }

            if (DataTransferElements.Count == 0)
            {
                Console.WriteLine("\n\nData transfer Succesfully!!!");

                return;
            }

            Console.WriteLine("After: Elements in Stack");

            foreach (var item in DataTransferElements)
            {
                Console.Write(item + " ");
            }
        }
    }
}