using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository.Interface
{

    /// <summary>
    /// This interface is used to mock the DbContext, <see cref="AutoSysDbModel"/>
    /// </summary>
    public interface IAutoSysContext : IDisposable
    {

        // Study entities 
        DbSet<StoredCriteria> Criterias { get; set; }
        DbSet<StoredPhase> Phases { get; set; }
        DbSet<StoredRole> Roles { get; set; }
        DbSet<StoredTaskRequest> Tasks { get; set; }
        DbSet<StoredDataField> Datafields { get; set; }
        DbSet<StoredStudy> Studies { get; set; }

        // User entities
        DbSet<StoredTeam> Teams { get; set; }
        DbSet<StoredUser> Users { get; set; }

        // Protocol entities
        DbSet<StoredProtocol> Protocols { get; set; }

        // Paper entities 
        DbSet<StoredPaper> Papers { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        // Used to allow mocking of dbContext.Entry<T>(item).State = EntityState.Modified; in UpdateIfExists method 
        void SetModified<TEntity>(TEntity entity) where TEntity : class, IEntity; 
        
        // Used to allow mocking of Set method in DbContext  
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        // Used to allow mocking of Attach when calling UpdateIfExists in DbContext 
        void Attach<TEntity>(TEntity entity) where TEntity : class;

        // Used to allow mocking of Attach when calling UpdateIfExists in DbContext 
        void Add<TEntity>(TEntity entity) where TEntity : class;

        // Used to allow mocking of Remove when calling DeleteIfExists in DbContext 
        void Remove<TEntity>(TEntity entity) where TEntity : class;
    }

    /// <summary>
    /// This is used to "instantiate" the interface when mocking, <see cref="IAutoSysContext"/>.
    /// </summary>
    public class AutoSysContext : DbContext, IAutoSysContext
    {
        public AutoSysContext() : base("name=AutoSysDbModel")
        {
            
        }

        public DbSet<StoredCriteria> Criterias { get; set; }
        public DbSet<StoredPhase> Phases { get; set; }
        public DbSet<StoredRole> Roles { get; set; }
        public DbSet<StoredTaskRequest> Tasks { get; set; }
        public DbSet<StoredDataField> Datafields { get; set; }
        public DbSet<StoredStudy> Studies { get; set; }
        public DbSet<StoredTeam> Teams { get; set; }
        public virtual DbSet<StoredUser> Users { get; set; }
        public DbSet<StoredProtocol> Protocols { get; set; }
        public DbSet<StoredPaper> Papers { get; set; }

        /// <summary>
        /// This allows mocking the UpdateIfExists functionality that is now hidden behind an interface. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void SetModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// This allows mocking the "_dbContext.Set<T>().Attach(item);" in the UpdateIfExists functionality that is now hidden behind an interface. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Attach(entity);
        }

        /// <summary>
        /// This allows mocking the "_dbContext.Set<T>().Add(item);" in the UpdateIfExists functionality that is now hidden behind an interface. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// This allows mocking the "_dbContext.Set<T>().Remove(item);" in the DeleteIfExists functionality that is now hidden behind an interface. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            Set<TEntity>().Remove(entity);
        }
    }
}
