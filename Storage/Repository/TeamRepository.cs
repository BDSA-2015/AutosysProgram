using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IAsyncRepository interface outlining the async CRUD operations to be used on teams in the
    ///     database. <see cref="StoredTeam" />
    ///     These are used specifically on a Team DbSet in the AutoSysDbModel.
    /// </summary>
    public class TeamRepository : IAsyncRepository<StoredTeam>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public TeamRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        ///     Creates a new team and returns its id. Throws an ArgumentNullException if the team to create is null.
        /// </summary>
        /// <param name="user">
        ///     Team to create.
        /// </param>
        /// <returns>
        ///     True if team was created.
        /// </returns>
        public virtual async Task<int> Create(StoredTeam user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _dbContext.Attach(user); // Used for mocking
            // _dbContext.Set<T>().Attach(team);
            _dbContext.Add(user); // Used for mocking 
            //_dbContext.Set<T>().Add(team);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        ///     Returns a team based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of team to find.
        /// </param>
        /// <returns>
        ///     Team from id.
        /// </returns>
        public virtual async Task<StoredTeam> Read(int id)
        {
            return await _dbContext.Set<StoredTeam>().FindAsync(id);
        }

        /// <summary>
        ///     Returns all teams.
        /// </summary>
        /// <returns>
        ///     All teams.
        /// </returns>
        public virtual IQueryable<StoredTeam> Read()
        {
            return _dbContext.Set<StoredTeam>().AsQueryable();
        }

        /// <summary>
        ///     Updates a team in the database if it already exists. If not, false is returned to indicate that no Update occurred.
        ///     If the team to update is null, an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="user">
        ///     Team to update.
        /// </param>
        /// <returns>
        ///     True if team was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredTeam user)
        {
            // if (user == null) throw new ArgumentNullException(nameof(user)); // Todo handle in application logic 

            var teamToUpdate = await _dbContext.Set<StoredTeam>().FindAsync(user.Id);

            if (teamToUpdate != null)
            {
                _dbContext.Attach(user); // Used for mocking 
                //_dbContext.Set<T>().Attach(team);
                _dbContext.SetModified(user); // Used for mocking 
                //dbContext.Entry<T>(team).State = EntityState.Modified; 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Deletes a team based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of entity.
        /// </param>
        /// <returns>
        ///     True if team was deleted, false if team does not exist.
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var teamToDelete = await _dbContext.Set<StoredTeam>().FindAsync(id);

            if (teamToDelete != null)
            {
                _dbContext.Set<StoredTeam>().Remove(teamToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
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