using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StorageAdapter.Interface;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{

    /// <summary>
    ///     This class is responsible for converting protocols in the logical layer to stored protocol entities in the storage layer and call appropriate database operations.
    /// </summary>
    public class ProtocolAdapter : IAdapter<Protocol, StoredProtocol>
    {

        private readonly IRepository<StoredProtocol> _protocolRepository;

        public ProtocolAdapter(IRepository<StoredProtocol> protocolRepository)
        {
            _protocolRepository = protocolRepository;   
        } 

        /// <summary>
        /// Creates a protocol by converting it to an entity in the storage layer and storing it in the database. 
        /// </summary>
        /// <param name="protocol">
        /// Protocol to be created. 
        /// </param>
        /// <returns>
        /// Id of created protocol. 
        /// </returns>
        public async Task<int> Create(Protocol protocol)
        {
            return await _protocolRepository.Create(Map(protocol));
        }

        /// <summary>
        /// Deletes a protocol if it exists in the storage layer as a stored protocol in the database. 
        /// </summary>
        /// <param name="id">
        /// Id of protocol to delete. 
        /// </param>
        /// <returns>
        /// True if protocol was deleted, false if it does not exist. 
        /// </returns>
        public async Task<bool> DeleteIfExists(int id)
        {
            return await _protocolRepository.DeleteIfExists(id);
        }

        /// <summary>
        ///     Returns all protocols. 
        /// </summary>
        /// <returns>
        ///     A set of protocols. 
        /// </returns>
        public IEnumerable<Protocol> Read()
        {
            foreach (var protocol in _protocolRepository.Read())
            {
                yield return Map(protocol);
            }
        }

        /// <summary>
        /// Reads a stored protocol from the storage layer and returns it as a protocol to the caller. 
        /// </summary>
        /// <param name="id">
        /// Id of protocol. 
        /// </param>
        /// <returns>
        /// Found protocol. 
        /// </returns>
        public async Task<Protocol> Read(int id)
        {
            return await Task.FromResult(Map(_protocolRepository.Read(id).Result));
        }

        /// <summary>
        /// Updates a protocol if it exists in the database based on its stored entity. 
        /// </summary>
        /// <param name="protocol">
        /// Protocol to update
        /// </param>
        /// <returns>
        /// True if protocol was updated, false if protocol does not exist. 
        /// </returns>
        public async Task<bool> UpdateIfExists(Protocol protocol)
        {
            return await _protocolRepository.UpdateIfExists(Map(protocol));
        }

        public StoredProtocol Map(Protocol item)
        {
            return Mapper.Map<StoredProtocol>(item);
        }

        public Protocol Map(StoredProtocol item)
        {
            return Mapper.Map<Protocol>(item);
        }


        public void Dispose()
        {
            _protocolRepository.Dispose();
        }

    }

}