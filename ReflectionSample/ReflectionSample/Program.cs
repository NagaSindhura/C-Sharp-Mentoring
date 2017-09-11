using System;
using System.Collections.Generic;
using ReflectionSample.Entity;
using ReflectionSample.GenericImplementations;

namespace ReflectionSample
{
    public class Program
    {
        public static void Main()
        {
            var genericType = new MakeGenericType();
            var stringGenericTypeResults = genericType.GetGenericTypes<string>("System.String");

            Console.WriteLine("List of Strings Invoked");
            stringGenericTypeResults.ForEach(Console.WriteLine);

            var genericStudents = genericType.GetGenericTypes<Student>("ReflectionSample.Entity.Student");

            Console.WriteLine("List of Students Invoked with reflection + delegate");

            genericStudents.ForEach(
                student =>
                    {
                        var eventInfo = student.GetType().GetEvent("StudentEvent");
                        var methodInfo = student.GetType().GetMethod("DisplayDetails");
                        var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, student, methodInfo);
                        eventInfo.AddEventHandler(student, handler);

                        student.Execute();
                    });

            Console.ReadLine();
        }
    }
}