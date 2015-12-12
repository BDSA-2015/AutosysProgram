using System;
using System.Linq;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageAdapter.Interface;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    /// <summary>
    ///     This class is responsible for the communication between application logic layer and storage layer.
    ///     This class will handle BibtexTags and convert them to the appropriate object that are to be propagated
    /// </summary>
    public class BibtexTagAdapter : IAdapter<BibtexTag>
    {
        private readonly IRepository<StoredBibtexTag> _bibtexTagRepository;

        public BibtexTagAdapter(IRepository<StoredBibtexTag> bibtexTagRepository)
        {
            _bibtexTagRepository = bibtexTagRepository;
        }

        /// <summary>
        ///     Creates a new StoredBibtexTag from the BibtexTag details and sends it to the repository
        /// </summary>
        /// <param name="tag">
        /// The BibtexTag to be stored
        /// </param>
        /// <returns>
        /// The Id of the created StoedBibtexTag in the database
        /// </returns>
        public Task<int> Create(BibtexTag tag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns a BibtexTag from the specified repository based on a given id.
        /// </summary>
        /// <param name="id">
        ///     The id of the requested BibtexTag
        /// </param>
        /// <returns>
        ///     The requested Bibtextag if it exists, null if non exists
        /// </returns>
        public Task<BibtexTag> Read(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns all BibtexTags in the specified repository.
        /// </summary>
        /// <returns>
        ///     All BibtexTags in the specified repository
        /// </returns>
        public IQueryable<BibtexTag> Read()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Updates a BibtexTag in the specified repository if it already exists. If not false is returned to indicate that no
        ///     UpdateIfExists occurred.
        ///     If the BibtexTag to update is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="tag">
        ///     BibtexTag to update.
        /// </param>
        /// <returns>
        ///     True if BibtexTag was updated, vice versa.
        /// </returns>
        public Task<bool> UpdateIfExists(BibtexTag tag)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Deletes a BibtexTag in the specified repository based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of the given BibtexTag.
        /// </param>
        /// <returns>
        ///     True if BibtexTag was deleted, false if BibtexTag does not exist.
        /// </returns>
        public Task<bool> DeleteIfExists(int id)
        {
            throw new System.NotImplementedException();
        }

        //TODO Refactor IAdapter Interface Mapper method(s)
        public BibtexTag Map(BibtexTag tag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     This method is used to dispose the context.
        /// </summary>
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
