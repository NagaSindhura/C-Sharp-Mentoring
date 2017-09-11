using System.Data.Entity;

namespace Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void ChangeState<TEntity>(TEntity entity, EntityState state) where TEntity : class;
        int SaveChanges();
        void Dispose();
    }
}