using System;

namespace ReflectionSample.Entity
{
    public class Student
    {
        public string StudentId { get; set; }

        public string Name { get; set; }

        public string DisplayDetails()
        {
            return $"Student Id: {StudentId}, Student Name: {Name}";
        }

        public void Execute()
        {
            if (StudentEvent != null)
            {
                Console.WriteLine(StudentEvent());
            }
        }

        public event Func<string> StudentEvent;
    }
}