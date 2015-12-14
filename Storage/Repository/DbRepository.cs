using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IRepository interface outlining the async CRUD operations to be used in the
    ///     database.
    ///     These are used specifically on a given DbSet in the AutoSysDbModel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public DbRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        public DbRepository()
        {
        }

        /// <summary>
        ///     Creates a new T entity and returns its id. Throws an ArgumentNullException if the item to create is null.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public virtual async Task<int> Create(T user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _dbContext.Attach(user); // Used for mocking
            // _dbContext.Set<T>().Attach(item);
            _dbContext.Add(user); // Used for mocking 
            //_dbContext.Set<T>().Add(item);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        ///     Returns an item based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of item to find.x 
        /// </param>
        /// <returns></returns>
        public virtual async Task<T> Read(int id)
        {
            return await _dbContext.Read<T>(id); // Used for mocking 
            //return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        ///     Returns all items of given type.
        /// </summary>
        /// <returns>
        ///     All entities.
        /// </returns>
        public virtual IQueryable<T> Read()
        {
            return _dbContext.Read<T>(); // Used for mocking 
            // return _dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        ///     Updates an item in the database if it already exists. If not false is returned to indicate that no UpdateIfExists
        ///     occurred.
        ///     If the item to update is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="user">
        ///     Item to update.
        /// </param>
        /// <returns>
        ///     True if item was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(T user)
        {
            //if (user == null) throw new ArgumentNullException(nameof(user));

            var entity = await _dbContext.Set<T>().FindAsync(user.Id);

            if (entity == null) return false;

            _dbContext.Attach(user); // Used for mocking 
            //_dbContext.Set<T>().Attach(item);
            _dbContext.SetModified(user); // Used for mocking 
            //dbContext.Entry<T>(item).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes an item based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of entity.
        /// </param>
        /// <returns>
        ///     True if item was deleted, false if item does not exist.
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity == null) return false;

            _dbContext.Remove(entity);
            //_dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     This method is used to dispose the context.
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}