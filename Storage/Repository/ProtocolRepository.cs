using System;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    /// <summary>
    ///     This class implements the IRepository interface outlining the async CRUD operations to be used on protocols in
    ///     the database. <see cref="StoredProtocol" />
    ///     These are used specifically on a Stored Protocol DbSet in the AutoSysDbModel.
    /// </summary>
    public class ProtocolRepository : IAsyncRepository<StoredProtocol>
    {
        private readonly IAutoSysContext _dbContext;

        // Used for mocking 
        public ProtocolRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        ///     Creates a new protocol and returns its id. Throws an ArgumentNullException if the protocol to create is null.
        /// </summary>
        /// <param name="protocol">
        ///     Protocol to create.
        /// </param>
        /// <returns>
        ///     True if protocol was created.
        /// </returns>
        public virtual async Task<int> Create(StoredProtocol protocol)
        {
            if (protocol == null) throw new ArgumentNullException(nameof(protocol));

            _dbContext.Attach(protocol); // Used for mocking
            // _dbContext.Set<T>().Attach(protocol);
            _dbContext.Add(protocol); // Used for mocking 
            //_dbContext.Set<T>().Add(protocol);
            await _dbContext.SaveChangesAsync();
            return protocol.Id;
        }

        /// <summary>
        ///     Returns an protocol based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of protocol to find.
        /// </param>
        /// <returns>
        ///     Protocol from id.
        /// </returns>
        public virtual async Task<StoredProtocol> Read(int id)
        {
            return await _dbContext.Set<StoredProtocol>().FindAsync(id);
        }

        /// <summary>
        ///     Returns all protocols.
        /// </summary>
        /// <returns>
        ///     All protocols.
        /// </returns>
        public virtual IQueryable<StoredProtocol> Read()
        {
            return _dbContext.Set<StoredProtocol>().AsQueryable();
        }

        /// <summary>
        ///     Updates an protocol in the database if it already exists. If not false is returned to indicate that no
        ///     UpdateIfExists occurred.
        ///     If the protocol to update is null an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="protocol">
        ///     Protocol to update.
        /// </param>
        /// <returns>
        ///     True if protocol was updated, vice versa.
        /// </returns>
        public virtual async Task<bool> UpdateIfExists(StoredProtocol protocol)
        {
            if (protocol == null) throw new ArgumentNullException(nameof(protocol));

            var protocolToUpdate = await _dbContext.Set<StoredProtocol>().FindAsync(protocol.Id);

            if (protocolToUpdate == null) return false;

            _dbContext.Attach(protocol); // Used for mocking 
            //_dbContext.Set<T>().Attach(protocol);
            _dbContext.SetModified(protocol); // Used for mocking 
            //dbContext.Entry<T>(protocol).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes an protocol based on its id.
        /// </summary>
        /// <param name="id">
        ///     Id of entity.
        /// </param>
        /// <returns>
        ///     True if protocol was deleted, false if protocol does not exist.
        /// </returns>
        public virtual async Task<bool> DeleteIfExists(int id)
        {
            var protocolToDelete = await _dbContext.Set<StoredProtocol>().FindAsync(id);

            if (protocolToDelete == null) return false;

            _dbContext.Set<StoredProtocol>().Remove(protocolToDelete);
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