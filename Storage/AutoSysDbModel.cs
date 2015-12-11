using System.Data.Entity;
using Storage.Entities;
using Storage.Models;

namespace Storage
{
    /// <summary>
    ///     This class is used to target a local database holding tables for all stored model entities in the system.
    ///     The context holds DbSets (tables) for all stored model entities and is used to apply changes to these in the
    ///     database.
    ///     The context has been configured to use a 'AutoSysDbModel' connection string from the configuration file
    ///     (App.config).
    ///     By default, this connection string targets the 'Storage.AutoSysDbModel' database on the LocalDb instance.
    /// </summary>
    public class AutoSysDbModel : DbContext
    {
        // The context has been configured to use a 'AutoSysDbModel' connection string from the configuration file(App.config).
        // By default, this connection string targets the 'Storage.AutoSysDbModel' database on the LocalDb instance. 
        public AutoSysDbModel()
            : base("name=AutoSysDbModel")
        {
        }

        // DbSets for all entity types included in the model 

        // Study entities 
        public virtual DbSet<StoredCriteria> Criterias { get; set; }
        public virtual DbSet<StoredPhase> Phases { get; set; }
        public virtual DbSet<StoredRole> Roles { get; set; }
        public virtual DbSet<StoredTaskRequest> Tasks { get; set; }
        public virtual DbSet<StoredDataField> Datafields { get; set; }
        public virtual DbSet<StoredStudy> Studies { get; set; }

        // User entities
        public virtual DbSet<StoredTeam> Teams { get; set; }
        public virtual DbSet<StoredUser> Users { get; set; }

        // Protocol entities
        public virtual DbSet<StoredProtocol> Protocols { get; set; }

        // Paper entities 
        public virtual DbSet<StoredPaper> Papers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Example of fluent API 
            modelBuilder.Entity<StoredUser>()
                .Property(u => u.Name)
                .HasColumnName("display_name");
            */
        }
    }
}