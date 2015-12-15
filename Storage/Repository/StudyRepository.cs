using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IRepository interface outlining the async CRUD operations to be used on studies in
    ///     the database. <see cref="StoredStudy" />
    ///     These are used specifically on a Stored Study DbSet in the AutoSysDbModel.
    /// </summary>
    public class StudyRepository : IRepository<StoredStudy>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public StudyRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        public StudyRepository()
        {
        }

        /// <summary>
        ///     Creates a new study and returns its id. Throws an ArgumentNullException if the study to create is null.
        /// </summary>
        /// <param name="study">
        ///     Study to create.
        /// </param>
        /// <returns>
        ///     True if study was created.
        /// </returns>
        public virtual async Task<int> Create(StoredStudy study)
        {
            if (study == null) throw new ArgumentNullException(nameof(study));

            _dbContext.Add(study); // Used for mocking 
            //_dbContext.Set<T>().Add(study);
            await _dbContext.SaveChangesAsync();
            return study.Id;
        }

        /// <summary>
        ///     Returns a study based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of study to find.
        /// </param>
        /// <returns>
        ///     Study from id.
        /// </returns>
        public virtual async Task<StoredStudy> Read(int id)
        {
            return await _dbContext.Read<StoredStudy>(id); // Used for mocking 
            //return await _dbContext.Set<StoredStudy>().FindAsync(id);
        }

        /// <summary>
        ///     Returns all studies.
        /// </summary>
        /// <returns>
        ///     All studies.
        /// </returns>
        public virtual IQueryable<StoredStudy> Read()
        {
            return _dbContext.Read<StoredStudy>(); // Used for mocking 
            // return _dbContext.Set<StoredStudy>().AsQueryable();
        }

        /// <summary>
        ///     Updates an study in the database if it already exists. If not false is returned to indicate that no UpdateIfExists
        ///     occurred.
        ///     If the study to update is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="study">
        ///     Study to update.
        /// </param>
        /// <returns>
        ///     True if study was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredStudy study)
        {
            // if (user == null) throw new ArgumentNullException(nameof(user)); // Todo handle in application logic 

            var studyToUpdate = await _dbContext.Set<StoredStudy>().FindAsync(study.Id);

            if (studyToUpdate == null) return false;

            _dbContext.Attach(study); // Used for mocking 
            //_dbContext.Set<T>().Attach(study);
            _dbContext.SetModified(study); // Used for mocking 
            //dbContext.Entry<T>(study).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes an study based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of entity.
        /// </param>
        /// <returns>
        ///     True if study was deleted, false if study does not exist.
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var studyToDelete = await _dbContext.Set<StoredStudy>().FindAsync(id);

            if (studyToDelete == null) return false;

            _dbContext.Remove(studyToDelete);
            //_dbContext.Set<StoredStudy>().Remove(studyToDelete);
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