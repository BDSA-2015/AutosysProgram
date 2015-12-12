using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IRepository interface outlining the async CRUD operations to be used on BibtexTags in
    ///     the database. <see cref="StoredBibtexTag" />
    ///     These are used specifically on a StoredBibtexTag DbSet in the AutoSysDbModel.
    /// </summary>
    public class BibtexTagRepository : IRepository<StoredBibtexTag>
    {
        private readonly IAutoSysContext _dbContext;

        //Used for mocking
        public BibtexTagRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        ///     Creates a new BibtexTag and returns its id. Throws an ArgumentNullException if the BibtexTag to create is null.
        /// </summary>
        /// <param name="tag">
        /// BibtexTag to create
        /// </param>
        /// <returns>
        /// True if the BibtexTag was created
        /// </returns>
        public virtual async Task<int> Create(StoredBibtexTag tag)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));

            _dbContext.Attach(tag); // Used for mocking
            _dbContext.Add(tag); // Used for mocking 
            await _dbContext.SaveChangesAsync();
            return tag.Id;
        }

        /// <summary>
        ///     Returns a BibtexTag based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of BibtexTag to find.
        /// </param>
        /// <returns>
        ///     BibtexTag from id.
        /// </returns>
        public virtual async Task<StoredBibtexTag> Read(int id)
        {
            return await _dbContext.Set<StoredBibtexTag>().FindAsync(id);
        }

        /// <summary>
        ///     Returns all BibtexTags.
        /// </summary>
        /// <returns>
        ///     All BibtexTags.
        /// </returns>
        public virtual IQueryable<StoredBibtexTag> Read()
        {
            return _dbContext.Set<StoredBibtexTag>().AsQueryable();
        }

        /// <summary>
        ///     Updates a BibtexTag in the database if it already exists. If not false is returned to indicate that no
        ///     UpdateIfExists occurred.
        ///     If the BibtexTag to update is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="tag">
        ///     BibtexTag to update.
        /// </param>
        /// <returns>
        ///     True if BibtexTag was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredBibtexTag tag)
        {
            var tagToUpdate = await _dbContext.Set<StoredBibtexTag>().FindAsync(tag.Id);

            if (tagToUpdate == null) return false;

            _dbContext.Attach(tag); // Used for mocking 
            _dbContext.SetModified(tag); // Used for mocking 
            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes a BibtexTag based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of BibtexTag.
        /// </param>
        /// <returns>
        ///     True if BibtexTag was deleted, false if BibtexTag does not exist.
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var bibtexTagToDelete = await _dbContext.Set<StoredBibtexTag>().FindAsync(id);

            if (bibtexTagToDelete == null) return false;

            _dbContext.Set<StoredBibtexTag>().Remove(bibtexTagToDelete);
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
