using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace StorageTests.Utility
{

    /// <summary>
    /// This interface is used to mock a DBContext with a DbSet of Stored Users. 
    /// </summary>
    public interface IUserContext : IDbContext
    {
        DbSet<StoredUser> Users { get; set; }

        new int SaveChanges();

        new Task<int> SaveChangesAsync();
    }

    public class UserContext : DbContext, IUserContext
    {
        public DbSet<StoredUser> Users { get; set; }
        new public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            throw new NotImplementedException();
        }
    }

  
}
