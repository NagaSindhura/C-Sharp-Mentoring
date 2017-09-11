using System.Linq;
using Entities;
using System.Data.Entity.Migrations;

namespace EF
{
    public class ProcessStudentUsingEF
    {
        private UniversityDbContext _dbContext;

        public ProcessStudentUsingEF()
        {
            _dbContext = new UniversityDbContext();
        }

        public void InsertStudent(Student student)
        {
            _dbContext.Students.AddOrUpdate(
                s => new { s.StudentName, s.SemisterId, s.UniversityId },
                new Student()
                {
                    StudentName = student.StudentName,
                    SemisterId =
                            _dbContext.Semisters.Where(p => p.SemisterName == student.Semister.SemisterName)
                                .Select(p => p.SemisterId)
                                .FirstOrDefault(),
                    UniversityId =
                            _dbContext.Universities.Where(p => p.UniversityName == student.University.UniversityName)
                                .Select(p => p.UniversityId)
                                .FirstOrDefault()
                });

            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Student student)

        {

            var SemisterId =
                _dbContext.Semisters.Where(p => p.SemisterName == student.Semister.SemisterName)
                    .Select(p => p.SemisterId)
                    .FirstOrDefault();
            var UniversityId =
                _dbContext.Universities.Where(p => p.UniversityName == student.University.UniversityName)
                    .Select(p => p.UniversityId)
                    .FirstOrDefault();

            var updateStudent = _dbContext.Students.Where(s => s.StudentName == student.StudentName).FirstOrDefault();
            updateStudent.SemisterId = SemisterId;
            updateStudent.UniversityId = UniversityId;

            _dbContext.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            var updateStudent = _dbContext.Students.Where(s => s.StudentName == student.StudentName).FirstOrDefault();
            _dbContext.Students.Remove(updateStudent);
            _dbContext.SaveChanges();
        }

        public string GetBestStudent()
        {
            var listStudents =
                _dbContext.Marks.GroupBy(m => new { m.StudentId, m.SemisterId })
                    .ToList()
                    .Select(
                        s =>
                            new
                                {
                                    SUM = s.Sum(m => m.Score),
                                    NME =
                                    this._dbContext.Students.Where(p => p.StudentID == s.Key.StudentId)
                                        .Select(q => q.StudentName)
                                        .FirstOrDefault()
                                })
                    .OrderByDescending(j => j.SUM)
                    .FirstOrDefault();

            return listStudents.NME;
        }

        public void UpdateStudentSemister(Student student)
        {
            var SemisterId =
                _dbContext.Semisters.Where(p => p.SemisterName == student.Semister.SemisterName)
                    .Select(p => p.SemisterId)
                    .FirstOrDefault();

            var updateStudent = _dbContext.Students.Where(s => s.StudentName == student.StudentName).FirstOrDefault();
            updateStudent.SemisterId = SemisterId;

            _dbContext.SaveChanges();
        }
    }
}