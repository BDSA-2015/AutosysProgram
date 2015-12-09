using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository.Interface
{
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

        void SetModified<TEntity>(TEntity entity) where TEntity : class, IEntity; // 
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }

    /// <summary>
    /// This is used to "instantiate" the interface. 
    /// </summary>
    class AutoSysContext : DbContext, IAutoSysContext
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
        public DbSet<StoredUser> Users { get; set; }
        public DbSet<StoredProtocol> Protocols { get; set; }
        public DbSet<StoredPaper> Papers { get; set; }



        /// <summary>
        /// This allows mocking the Update functionality that is now hidden behind an interface. 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public void SetModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Entry(entity).State = EntityState.Modified;
        }

    }
}
