using System;
using ADONET;
using Interfaces;

namespace University
{
    public class AdoDataProcess : IStudent
    {
        private ProcessStudentUsingADO Student { get; set; }

        private ProcessUniversityUsingADO University { get; set; }

        public AdoDataProcess()
        {
            Student = new ProcessStudentUsingADO();
            University = new ProcessUniversityUsingADO();
        }
        public void InsertStudent()
        {
            Console.WriteLine("Enter Student Details to Insert");
            var student = UserInput.GetStudentDetails();
            Student.InsertStudent(student);
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter Student Details to Update");

            var student = UserInput.GetStudentDetails();
            Student.UpdateStudent(student);
        }

        public void DeleteStudent()
        {
            var student = UserInput.DeleteStudentDetails();
            Student.DeleteStudent(student);
        }

        public void GetBestStudent()
        {
            Console.WriteLine("Enter Student Details  to get the best Student");
            var universityName = Console.ReadLine();
            var bestStudent = Student.GetBestStudent(universityName);
            Console.WriteLine(bestStudent);
        }

        public void UpdateStudentSemister()
        {
            var student = UserInput.GetStudentSemister();

            Student.UpdateStudentSemister(student);
        }
    }
}