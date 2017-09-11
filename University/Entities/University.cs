using System;
using System.Configuration;
using Interfaces;

namespace Entities
{
    using global::University;

    public class Program
    {
        //TODO: our overall implementation looks fine and you got the idea of configurable ADO.NET and EF code
        //tODO: Just that the code could be a bit better structured, conceptually looks good, will discuss in person
        public static IStudent student;

        public static void Main()
        {
            switch (ConfigurationManager.AppSettings["DALSwitch"])
            {
                case "0":
                    student = new AdoDataProcess();
                    break;
                case "1":
                    student = new EFDataProcessor();
                    break;
            }

            student.InsertStudent();
            student.UpdateStudent();
            student.DeleteStudent();
            student.GetBestStudent();
            student.UpdateStudentSemister();

            Console.ReadLine();
        }
    }
}