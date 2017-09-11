using System.Collections.Generic;
using Entities;

namespace Interfaces
{
    public interface IUniversityService
    {
        List<University> GetAll();
        University GetById(int id);
        void Insert(University model);
        void Update(University model);
        void Delete(University model);
    }
}