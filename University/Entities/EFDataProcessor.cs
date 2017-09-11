using System;
using EF;
using Interfaces;

namespace University
{
    public class EFDataProcessor : IStudent
    {
        public ProcessStudentUsingEF studentData { get; set; }
        public EFDataProcessor()
        {
            studentData = new ProcessStudentUsingEF();
        }
        public void DeleteStudent()
        {
            var student = UserInput.DeleteStudentDetails();
            studentData.DeleteStudent(student);
        }

        public void GetBestStudent()
        {
            var bestStudent = studentData.GetBestStudent();
            Console.WriteLine(bestStudent);
        }

        public void InsertStudent()
        {
            Console.WriteLine("Enter Student Details to Insert");
            var student = UserInput.GetStudentDetails();
            studentData.InsertStudent(student);
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter Student Details to Insert");
            var student = UserInput.GetStudentDetails();
            studentData.UpdateStudent(student);
        }

        public void UpdateStudentSemister()
        {
            var student = UserInput.GetStudentSemister();
            studentData.UpdateStudentSemister(student);
        }
    }
}