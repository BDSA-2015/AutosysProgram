using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IRepository interface outlining the async CRUD operations to be used on teams in the
    ///     database. <see cref="StoredTeam" />
    ///     These are used specifically on a Team DbSet in the AutoSysDbModel.
    /// </summary>
    public class TeamRepository : IRepository<StoredTeam>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public TeamRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        public TeamRepository()
        {
        }

        /// <summary>
        ///     Creates a new team and returns its id. Throws an ArgumentNullException if the team to create is null.
        /// </summary>
        /// <param name="team">
        ///     Team to create.
        /// </param>
        /// <returns>
        ///     True if team was created.
        /// </returns>
        public virtual async Task<int> Create(StoredTeam team)
        {
            if (team == null) throw new ArgumentNullException(nameof(team));

            _dbContext.Attach(team); // Used for mocking
            // _dbContext.Set<T>().Attach(team);
            _dbContext.Add(team); // Used for mocking 
            //_dbContext.Set<T>().Add(team);
            await _dbContext.SaveChangesAsync();
            return team.Id;
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
            return await _dbContext.Read<StoredTeam>(id); // Used for mocking 
            // return await _dbContext.Set<StoredTeam>().FindAsync(id);
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
        /// <param name="team">
        ///     Team to update.
        /// </param>
        /// <returns>
        ///     True if team was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredTeam team)
        {
            // if (team == null) throw new ArgumentNullException(nameof(team)); // Todo handle in application logic 

            var teamToUpdate = await _dbContext.Set<StoredTeam>().FindAsync(team.Id);

            if (teamToUpdate == null) return false;

            _dbContext.Attach(team); // Used for mocking 
            //_dbContext.Set<T>().Attach(team);
            _dbContext.SetModified(team); // Used for mocking 
            //dbContext.Entry<T>(team).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();

            return true;
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

            if (teamToDelete == null) return false;

            _dbContext.Set<StoredTeam>().Remove(teamToDelete);
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