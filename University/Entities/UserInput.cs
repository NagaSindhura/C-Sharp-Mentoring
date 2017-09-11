using Entities;
using System;

namespace University
{
    using University = Entities.University;

    public class UserInput
    {
        public static Student GetStudentDetails()
        {
            var student = new Student();


            Console.WriteLine("StudentName");
            student.StudentName = Console.ReadLine();

            Console.WriteLine("Enter Student University");
            student.University = new University { UniversityName = Console.ReadLine() };

            Console.WriteLine("Enter Student Semister");
            student.Semister = new Semister() { SemisterName = Console.ReadLine() };

            return student;
        }

        public static Student DeleteStudentDetails()
        {
            var student = new Student();


            Console.WriteLine("StudentName");
            student.StudentName = Console.ReadLine();

            Console.WriteLine("Enter Student University");
            student.University = new University { UniversityName = Console.ReadLine() };

            Console.WriteLine("Enter Student Semister");
            student.Semister = new Semister() { SemisterName = Console.ReadLine() };

            return student;
        }

        public static string GetUniversityName()
        {
            Console.WriteLine("Enter Student Details  to get the best Student");
            return Console.ReadLine();
        }

        public static Student GetStudentSemister()
        {
            var student = new Student();
            Console.WriteLine("Enter Student Details  to Update the semister");

            Console.WriteLine("StudentName");
            student.StudentName = Console.ReadLine();

            Console.WriteLine("NewSemisterName");
            student.Semister.SemisterName = Console.ReadLine();

            return student;
        }
    }
}