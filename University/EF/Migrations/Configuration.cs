using Entities;
using System.Data.Entity.Migrations;
using System.Linq;

namespace EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EF.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EF.UniversityDbContext context)
        {
            //context.Universities.AddOrUpdate(
            //    p => p.UniversityName,
            //    new University { UniversityName = "JNTU Kakinaga", });

            //context.Semisters.AddOrUpdate(s => s.SemisterName, new Semister { SemisterName = "Semister1" });

            //context.Subjects.AddOrUpdate(
            //    s => new { s.SubjectName, s.SemisterId },
            //    new Subject
            //    {
            //        SubjectName = "Subject1",
            //        SemisterId =
            //                context.Semisters.Where(p => p.SemisterName == "Semister1")
            //                    .Select(p => p.SemisterId)
            //                    .FirstOrDefault()
            //    }
            //    //,
            //    //new Subject
            //    //{
            //    //    SubjectName = "Subject2",
            //    //    SemisterId =
            //    //            context.Semisters.Where(p => p.SemisterName == "Semister1")
            //    //                .Select(p => p.SemisterId)
            //    //                .FirstOrDefault()
            //    //}
                
            //    );

            //context.Students.AddOrUpdate(
            //    s => new { s.StudentName, s.SemisterId, s.UniversityId },
            //    new Student()
            //    {
            //        StudentName = "Student1",
            //        SemisterId =
            //                context.Semisters.Where(p => p.SemisterName == "Semister1")
            //                    .Select(p => p.SemisterId)
            //                    .FirstOrDefault(),
            //        UniversityId =
            //                context.Universities.Where(p => p.UniversityName == "JNTU Hyderabad")
            //                    .Select(p => p.UniversityId)
            //                    .FirstOrDefault()
            //    });

            //context.Marks.AddOrUpdate(
            //    m => new { m.SemisterId, m.StudentId, m.SubjectId, m.Score },
            //    new Mark()
            //    {
            //        SemisterId =
            //                context.Semisters.Where(p => p.SemisterName == "Semister1")
            //                    .Select(p => p.SemisterId)
            //                    .FirstOrDefault(),
            //        StudentId =
            //                context.Students.Where(p => p.StudentName == "Student1")
            //                    .Select(p => p.StudentID)
            //                    .FirstOrDefault(),
            //        SubjectId =
            //                context.Subjects.Where(p => p.SubjectName == "Subject1")
            //                    .Select(p => p.SubjectId)
            //                    .FirstOrDefault(),
            //        Score = 75
            //    }
            //    //,
            //    //new Mark()
            //    //{
            //    //    SemisterId =
            //    //            context.Semisters.Where(p => p.SemisterName == "Semister1")
            //    //                .Select(p => p.SemisterId)
            //    //                .FirstOrDefault(),
            //    //    StudentId =
            //    //            context.Students.Where(p => p.StudentName == "Student1")
            //    //                .Select(p => p.StudentID)
            //    //                .FirstOrDefault(),
            //    //    SubjectId =
            //    //            context.Subjects.Where(p => p.SubjectName == "Subject2")
            //    //                .Select(p => p.SubjectId)
            //    //                .FirstOrDefault(),
            //    //    Score = 75
            //    //}
            //    );
        }
    }
}
