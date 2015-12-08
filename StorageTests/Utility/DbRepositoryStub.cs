using System.Collections.Generic;
using System.Data.Entity;
using Storage;
using Storage.Repository.Interface;

namespace StorageTests.Utility
{

    /// <summary>
    /// This is a test stub of the generic DbRepository in storage used to mock the repository with an interface instead of a concrete DbContext. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbRepositoryStub<T> : IRepository<T> where T : class, IEntity
    {

        private readonly IDbContext _context;

        // Used for mocking 
        public DbRepositoryStub(IDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates an item from a given Dbset in the <see cref="AutoSysDbModel"/>, e.g. Stored Users.
        /// </summary>
        /// <param name="item">
        /// Entity to create.
        /// </param>
        public virtual int CreateOrUpdate(T item)
        {
            using (var _context = new AutoSysDbModel())
            {
                var entity = _context.Set<T>().Find(item.Id);

                if (entity == null)
                {
                    _context.Set<T>().Add(item);
                    _context.SaveChanges();
                    return item.Id;
                }

                else
                {
                    _context.Set<T>().Attach(item);
                    _context.Entry<T>(item).State = EntityState.Modified;
                    _context.SaveChanges();
                    return item.Id;
                }

            }

        }

        /// <summary>
        /// Reads a specific item from a given DbSet based on its id. 
        /// </summary>
        /// <param name="id">
        /// Entity with given id. 
        /// </param>
        public virtual T Read(int id)
        {
            using (var context = new AutoSysDbModel())
            {
                return context.Set<T>().Find(id);
            }
        }

        /// <summary>
        /// Reads all stored items in a given DbSet. 
        /// </summary>
        public virtual IEnumerable<T> Read()
        {
            using (var context = new AutoSysDbModel())
            {
                return context.Set<T>();
            }
        }

        /// <summary>
        /// Updates an item from a given Dbset in the <see cref="AutoSysDbModel"/>, e.g. Stored Users.
        /// </summary>
        /// <param name="item">
        /// Entity to update.
        /// </param>
        public virtual void UpdateIfExists(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Set<T>().Find(item.Id);

                if (entity != null)
                {
                    context.Set<T>().Attach(item);
                    context.Entry<T>(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes an item from a given Dbset in the <see cref="AutoSysDbModel"/>, e.g. Stored Users.
        /// </summary>
        /// <param name="item">
        /// Entity to delete. 
        /// </param>
        public virtual void DeleteIfExists(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Set<T>().Find(item.Id);

                if (entity != null)
                {
                    context.Set<T>().Remove(item);
                    context.SaveChanges();
                }
            }
        }

    }

}
