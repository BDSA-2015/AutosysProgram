using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class implements the IAsyncRepository interface outlining the async CRUD operations to be used on task requests in the database. <see cref="StoredTaskRequest"/>
    /// These are used specifically on a Task DbSet in the AutoSysDbModel.
    /// </summary>
    public class TaskRepository : IAsyncRepository<StoredTaskRequest>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public TaskRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Creates a new task and returns its id. Throws an ArgumentNullException if the task to create is null. 
        /// </summary>
        /// <param name="user">
        /// Task to create. 
        /// </param>
        /// <returns>
        /// True if task was created. 
        /// </returns>
        public virtual async Task<int> Create(StoredTaskRequest user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _dbContext.Attach(user); // Used for mocking
            // _dbContext.Set<T>().Attach(task);
            _dbContext.Add(user); // Used for mocking 
            //_dbContext.Set<T>().Add(task);
            await _dbContext.SaveChangesAsync();
            return user.Id;

        }

        /// <summary>
        /// Returns a task based on its id.
        /// </summary>
        /// <param name="id">
        /// Id of task to find. 
        /// </param>
        /// <returns>
        /// Task from id. 
        /// </returns>
        public virtual async Task<StoredTaskRequest> Read(int id)
        {

            return await _dbContext.Set<StoredTaskRequest>().FindAsync(id);

        }

        /// <summary>
        /// Returns all tasks. 
        /// </summary>
        /// <returns>
        /// All tasks. 
        /// </returns>
        public virtual IQueryable<StoredTaskRequest> Read()
        {

            return _dbContext.Set<StoredTaskRequest>().AsQueryable();

        }

        /// <summary>
        /// Updates a task in the database if it already exists. If not, false is returned to indicate that no UpdateIfExists occurred.
        /// If the task to update is null, an ArgumentNullException is thrown. 
        /// </summary>
        /// <param name="user">
        /// Task to update.
        /// </param>
        /// <returns>
        /// True if task was updated, vice versa. 
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredTaskRequest user)
        {
            // if (user == null) throw new ArgumentNullException(nameof(user)); // Todo handle in application logic 

            var taskToUpdate = await _dbContext.Set<StoredTaskRequest>().FindAsync(user.Id);

            if (taskToUpdate != null)
            {
                _dbContext.Attach(user); // Used for mocking 
                //_dbContext.Set<T>().Attach(task);
                _dbContext.SetModified(user); // Used for mocking 
                //dbContext.Entry<T>(task).State = EntityState.Modified; 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        /// <summary>
        /// Deletes a user based on its id. 
        /// </summary>
        /// <param name="id">
        /// Id of entity. 
        /// </param>
        /// <returns>
        /// True if user was deleted, false if user does not exist. 
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var userToDelete = await _dbContext.Set<StoredTaskRequest>().FindAsync(id);

            if (userToDelete != null)
            {
                _dbContext.Set<StoredTaskRequest>().Remove(userToDelete);
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
