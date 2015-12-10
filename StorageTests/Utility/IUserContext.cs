//using System;
//using System.Data.Entity;
//using System.Threading.Tasks;
//using Storage.Models;

//namespace StorageTests.Utility
//{

//    /// <summary>
//    /// This interface is used to mock a DBContext with a DbSet of Stored Users. 
//    /// </summary>
//    public interface IUserContext : IDisposable // : IDbContext
//    {
//        DbSet<StoredUser> Users { get; set; }

//        int SaveChanges();

//        Task<int> SaveChangesAsync();
//    }

//    /*
//    public class UserContext : DbContext, IUserContext
//    {
//        public DbSet<StoredUser> Users { get; set; }

//        new public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class, IEntity
//        {
//            throw new NotImplementedException();
//        }
//    }
//    */

  
//}
