using Entities;

namespace Interfaces
{
    //TODO: NAming convention
    public interface IADOStudentData
    {
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);
        string GetBestStudent(string universityName);
        void UpdateStudentSemister(Student student);
    }
}