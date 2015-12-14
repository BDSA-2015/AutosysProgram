using System;
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
    public class ProtocolAdapter : IAdapter<Protocol>
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
            var storedProtocol = Mapper.Map<StoredProtocol>(protocol);
            return await _protocolRepository.Create(storedProtocol);
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

        // TODO remove from interface? 
        public Protocol Map(Protocol item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Returns all protocols. 
        /// </summary>
        /// <returns>
        ///     A set of protocols. 
        /// </returns>
        public IQueryable<Protocol> Read()
        {
            var storedProtocols = _protocolRepository.Read();
            return storedProtocols.Select(Mapper.Map<Protocol>).AsQueryable();
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
            var storedProtocol = await _protocolRepository.Read(id);
            return Mapper.Map<Protocol>(storedProtocol);
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
            var storedProtocol = Mapper.Map<StoredProtocol>(protocol);
            return await _protocolRepository.UpdateIfExists(storedProtocol);
        }

        public void Dispose()
        {
            _protocolRepository.Dispose();
        }

    }

}