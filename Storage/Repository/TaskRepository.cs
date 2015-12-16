using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IRepository interface outlining the async CRUD operations to be used on task
    ///     requests in the database. <see cref="StoredTaskRequest" />
    ///     These are used specifically on a Task DbSet in the AutoSysDbModel.
    /// </summary>
    public class TaskRepository : IRepository<StoredTaskRequest>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public TaskRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        public TaskRepository()
        {
        }

        /// <summary>
        ///     Creates a new task and returns its id. Throws an ArgumentNullException if the task to create is null.
        /// </summary>
        /// <param name="task">
        ///     Task to create.
        /// </param>
        /// <returns>
        ///     True if task was created.
        /// </returns>
        public virtual async Task<int> Create(StoredTaskRequest task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            _dbContext.Add(task); // Used for mocking 
            //_dbContext.Set<T>().Add(task);
            await _dbContext.SaveChangesAsync();
            return task.Id;
        }

        /// <summary>
        ///     Returns a task based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of task to find.
        /// </param>
        /// <returns>
        ///     Task from id.
        /// </returns>
        public virtual async Task<StoredTaskRequest> Read(int id)
        {
            return await _dbContext.Read<StoredTaskRequest>(id);
            //return await _dbContext.Set<StoredTaskRequest>().FindAsync(id);
        }

        /// <summary>
        ///     Returns all tasks.
        /// </summary>
        /// <returns>
        ///     All tasks.
        /// </returns>
        public virtual IQueryable<StoredTaskRequest> Read()
        {
            return _dbContext.Read<StoredTaskRequest>(); // Used for mocking 
            //return _dbContext.Set<StoredTaskRequest>().AsQueryable();
        }

        /// <summary>
        ///     Updates a task in the database if it already exists. If not, false is returned to indicate that no UpdateIfExists
        ///     occurred.
        ///     If the task to update is null, an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="task">
        ///     Task to update.
        /// </param>
        /// <returns>
        ///     True if task was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredTaskRequest task)
        {
            // if (user == null) throw new ArgumentNullException(nameof(user)); // Todo handle in application logic 

            var taskToUpdate = await _dbContext.Set<StoredTaskRequest>().FindAsync(task.Id);

            if (taskToUpdate == null) return false;

            _dbContext.Attach(task); // Used for mocking 
            //_dbContext.Set<T>().Attach(task);
            //_dbContext.SetModified(task); // Used for mocking 
            //dbContext.Entry<T>(task).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes a user based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of entity.
        /// </param>
        /// <returns>
        ///     True if user was deleted, false if user does not exist.
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var userToDelete = await _dbContext.Set<StoredTaskRequest>().FindAsync(id);

            if (userToDelete == null) return false;

            _dbContext.Remove(userToDelete);
            //_dbContext.Set<StoredTaskRequest>().Remove(userToDelete);
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