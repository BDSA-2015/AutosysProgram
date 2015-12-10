using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class implements the IAsyncRepository interface outlining the async CRUD operations to be used on users in the database. <see cref="StoredUser"/>
    /// These are used specifically on a User DbSet in the AutoSysDbModel.
    /// </summary>
    public class UserRepository : IAsyncRepository<StoredUser>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public UserRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Creates a new user and returns its id. Throws an ArgumentNullException if the user to create is null. 
        /// </summary>
        /// <param name="user">
        /// User to create. 
        /// </param>
        /// <returns>
        /// True if user was created. 
        /// </returns>
        public async Task<int> Create(StoredUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _dbContext.Attach(user); // Used for mocking
            // _dbContext.Set<T>().Attach(user);
            _dbContext.Add(user); // Used for mocking 
            //_dbContext.Set<T>().Add(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;

        }

        /// <summary>
        /// Returns a user based on its id.
        /// </summary>
        /// <param name="id">
        /// Id of user to find. 
        /// </param>
        /// <returns>
        /// User from id. 
        /// </returns>
        public async Task<StoredUser> Read(int id)
        {
            return await _dbContext.Set<StoredUser>().FindAsync(id);
        }

        /// <summary>
        /// Returns all users. 
        /// </summary>
        /// <returns>
        /// All users. 
        /// </returns>
        public virtual IQueryable<StoredUser> Read()
        {
            return _dbContext.Set<StoredUser>().AsQueryable();
        }

        /// <summary>
        /// Updates a user in the database if it already exists. If not, false is returned to indicate that no UpdateIfExists occurred.
        /// If the user to update is null, an ArgumentNullException is thrown. 
        /// </summary>
        /// <param name="user">
        /// User to update.
        /// </param>
        /// <returns>
        /// True if user was updated, vice versa. 
        /// </returns>
        public async Task<bool> UpdateIfExists(StoredUser user)
        {
            // if (user == null) throw new ArgumentNullException(nameof(user)); // TODO handle in above fasade/adapter layer 

            var userToUpdate = await _dbContext.Set<StoredUser>().FindAsync(user.Id);

            if (userToUpdate != null)
            {
                _dbContext.Attach(user); // Used for mocking 
                //_dbContext.Set<T>().Attach(user);
                _dbContext.SetModified(user); // Used for mocking 
                //dbContext.Entry<T>(user).State = EntityState.Modified; 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        /// <summary>
        /// Deletes a user based on its id. 
        /// </summary>
        /// <param name="id">
        /// Id of user. 
        /// </param>
        /// <returns>
        /// True if user was deleted, false if user does not exist. 
        /// </returns>
        public async Task<bool> DeleteIfExists(int id)
        {
            var userToDelete = await _dbContext.Set<StoredUser>().FindAsync(id);

            if (userToDelete != null)
            {
                _dbContext.Remove(userToDelete); // Used for mocking 
                //_dbContext.Set<StoredUser>().Remove(userToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// This method is used to dispose the context.
        /// </summary>
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }

}
