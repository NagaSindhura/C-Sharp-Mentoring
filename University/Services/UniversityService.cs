using System;
using System.Collections.Generic;
using Entities;
using Interfaces;
using Service;
using System.Linq;

namespace Services
{
    public class UniversityService : IUniversityService
    {
        private IRepository<University> UniversityRepository;
        //TODO: Naming convention
        public UniversityService(IRepository<University> UniversityRepository)
        {
            this.UniversityRepository = UniversityRepository;
        }

        public List<University> GetAll()
        {
            return UniversityRepository.GetAll().ToList();
        }

        public University GetById(int id)
        {
            return id == 0 ? null : this.UniversityRepository.GetById(id);
        }

        public void Insert(University model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("University");
            }

            UniversityRepository.Insert(model);
        }

        public void Update(University model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("University");
            }

            UniversityRepository.Update(model);
        }

        public void Delete(University model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("University");
            }

            UniversityRepository.Delete(model);
        }
    }
}