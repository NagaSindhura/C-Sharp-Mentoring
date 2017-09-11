using System;
using System.Linq;
using System.Data.Entity;
using EF;
using Interfaces;
using Service;

namespace Services
{
    public class RepositoryService<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IDbContext Context;
        private UniversityDbContext sbContext = new UniversityDbContext();

        private IDbSet<TEntity> Entities => Context.Set<TEntity>();

        public RepositoryService(IDbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
            this.Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Context.Set<TEntity>().Attach(entity);
            Context.ChangeState(entity, EntityState.Modified);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.ChangeState(entity, EntityState.Deleted);
            Entities.Remove(entity);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context == null)
                {
                    return;
                }

                Context.Dispose();
                Context = null;
            }
        }
    }
}