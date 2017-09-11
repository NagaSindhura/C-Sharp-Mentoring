using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF
{
    public class UniversityDbContext : DbContext//, IDbContext
    {
        public UniversityDbContext() : base("UniversityDbContext")
        {
            //Database.SetInitializer(new Configuration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Semister> Semisters { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        //    //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
        //    //.Where(type => !string.IsNullOrEmpty(type.Namespace))
        //    //.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
        //    //foreach (var type in typesToRegister)
        //    //{
        //    //    dynamic configurationInstance = Activator.CreateInstance(type);
        //    //    modelBuilder.Configurations.Add(configurationInstance);
        //    //}

        //    //base.OnModelCreating(modelBuilder);
        //}

        //public void ChangeState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        //{
        //    base.Entry(entity).State = state;
        //}

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        //{
        //    return base.Set<TEntity>();
        //}
    }
}