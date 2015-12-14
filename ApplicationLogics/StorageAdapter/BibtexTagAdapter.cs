using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageAdapter.Interface;
using AutoMapper;
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
        /// The Id of the created StoredBibtexTag in the database
        /// </returns>
        public async Task<int> Create(BibtexTag tag)
        {
            var storedTag = Mapper.Map<StoredBibtexTag>(tag);
            return await _bibtexTagRepository.Create(storedTag);
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
        public async Task<BibtexTag> Read(int id)
        {
            var storedUser = await _bibtexTagRepository.Read(id);
            var convertedUser = Mapper.Map<BibtexTag>(storedUser);
            return convertedUser;
        }

        /// <summary>
        ///     Returns all BibtexTags in the specified repository.
        /// </summary>
        /// <returns>
        ///     All BibtexTags in the specified repository
        /// </returns>
        public IQueryable<BibtexTag> Read()
        {
            var storedTags = _bibtexTagRepository.Read();
            return storedTags.Select(Mapper.Map<BibtexTag>).AsQueryable();
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
        public async Task<bool> UpdateIfExists(BibtexTag tag)
        {
            var storedTag = Mapper.Map<StoredBibtexTag>(tag);
            return await _bibtexTagRepository.UpdateIfExists(storedTag);
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
        public async Task<bool> DeleteIfExists(int id)
        {
            return await _bibtexTagRepository.DeleteIfExists(id);
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
            _bibtexTagRepository.Dispose();
        }

    }

}
