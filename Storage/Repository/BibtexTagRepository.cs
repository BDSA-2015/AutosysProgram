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
        ///     Creates a new BibtexTag and returns its id. Throws an ArgumentNullException if the bibtextag to create is null.
        /// </summary>
        /// <param name="tag">
        /// BibtexTag to create
        /// </param>
        /// <returns>
        /// True if the BibtexTag was created
        /// </returns>
        public Task<int> Create(StoredBibtexTag tag)
        {
            throw new NotImplementedException();
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
        public Task<StoredBibtexTag> Read(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns all BibtexTags.
        /// </summary>
        /// <returns>
        ///     All BibtexTags.
        /// </returns>
        public IQueryable<StoredBibtexTag> Read()
        {
            throw new NotImplementedException();
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
        public Task<bool> UpdateIfExists(StoredBibtexTag tag)
        {
            throw new NotImplementedException();
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
        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     This method is used to dispose the context.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
