using System;
using System.Collections.Generic;
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
    ///     This class is responsible for converting papers in the logical layer to stored user entities in the storage layer and call appropriate database operations.
    /// </summary>
    public class PaperAdapter : IAdapter<Paper>
    {

        private readonly IRepository<StoredPaper> _paperRepository;

        public PaperAdapter(IRepository<StoredPaper> paperRepository)
        {
            _paperRepository = paperRepository;
        }

        /// <summary>
        /// Creates a paper and converts it to a stored paper in the storage layer that is stored in the database. 
        /// </summary>
        /// <param name="paper">
        /// Paper to be created. 
        /// </param>
        /// <returns>
        /// Id of newly created paper. 
        /// </returns>
        public async Task<int> Create(Paper paper)
        {
            var storedPaper = Mapper.Map<StoredPaper>(paper);
            return await _paperRepository.Create(storedPaper);
        }

        /// <summary>
        /// Returns a paper based on its id. 
        /// </summary>
        /// <param name="id">
        /// Id of retrieved paper. 
        /// </param>
        /// <returns>
        /// Found paper. 
        /// </returns>
        public async Task<Paper> Read(int id)
        {
            return Mapper.Map<Paper>(await _paperRepository.Read(id));
        }

        /// <summary>
        /// Return all papers. 
        /// </summary>
        /// <returns>
        /// All papers. 
        /// </returns>
        public IQueryable<Paper> Read()
        {
            var storedUsers = _paperRepository.Read();
            return storedUsers.Select(Mapper.Map<Paper>).AsQueryable();
        }

        /// <summary>
        /// Updates a paper if it is already stored through the storage layer in the database. 
        /// </summary>
        /// <param name="paper">
        /// Paper to update.
        /// </param>
        /// <returns>
        /// True if paper was updated. 
        /// </returns>
        public async Task<bool> UpdateIfExists(Paper paper)
        {
            var storedPaper = Mapper.Map<StoredPaper>(paper);
            return await _paperRepository.UpdateIfExists(storedPaper);
        }

        /// <summary>
        /// Deletes a paper if it exists. 
        /// </summary>
        /// <param name="id">
        /// Id of paper to delete. 
        /// </param>
        /// <returns>
        /// True if paper was deleted, false if paper does not exist.
        /// </returns>
        public async Task<bool> DeleteIfExists(int id)
        {
            return await _paperRepository.DeleteIfExists(id);
        }

        // TODO remove Map from interface? 
        public Paper Map(Paper item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
           _paperRepository.Dispose();
        }

    }
    
}