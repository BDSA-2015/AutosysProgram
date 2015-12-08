using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using Storage.Repository.Interface;

namespace StorageTests.Utility
{

    /// <summary>
    /// This interface is used to mock a database context with a collection of stored entities. 
    /// </summary>
    public interface IDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync();

        /// <summary>
        /// Tells compiler that the interface has DbContext in its inheritance tree.
        /// See link for more info: http://stackoverflow.com/questions/30791654/how-do-i-access-dbcontext-entrytentity-method-tentity-in-my-generic-reposito 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class, IEntity; 
    }

}
