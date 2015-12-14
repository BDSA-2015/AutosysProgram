using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement.Entities;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    /// <summary>
    ///     This class is responsible for converting users in the logical layer to stored user entities in the storage layer and call appropriate database operations.
    /// </summary>
    public class UserAdapter : IAdapter<User>
    {
        private readonly IRepository<StoredUser> _userRepository;

        /// <summary>
        ///     This class is responsible for the communication between application logic layer and storage layer.
        ///     This class will handle Users and convert them the the propriate object that are to be propagated
        /// </summary>
        public UserAdapter(IRepository<StoredUser> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Reads a stored user from the storage layer and returns it as a user to the caller.
        /// </summary>
        /// <param name="id"> 
        /// Id of user in database.
        /// </param>
        /// <returns>
        /// User object. 
        /// </returns>
        public async Task<User> Read(int id)
        {
            var user = Mapper.Map<User>(await _userRepository.Read(id));
            return user;
        }

        /// <summary>
        ///     Returns all users. 
        /// </summary>
        /// <returns>
        ///     A set of users. 
        /// </returns>
        public IQueryable<User> Read()
        {
            var storedUsers = _userRepository.Read();
            return storedUsers.Select(Mapper.Map<User>).AsQueryable();
        }

        /// <summary>
        ///     Updates a user if it exists in the storage layer. 
        /// </summary>
        /// <param name="user">
        /// User to be updated.
        /// </param>
        public async Task<bool> UpdateIfExists(User user)
        {
            return await _userRepository.UpdateIfExists(Mapper.Map<StoredUser>(user));
        }

        /// <summary>
        ///     Deletes a user if it exists in the storage layer in the database. 
        /// </summary>
        /// <param name="id">id of user</param>
        public async Task<bool> DeleteIfExists(int id)
        {
            var result = await _userRepository.DeleteIfExists(id);
            if (!result) throw new NullReferenceException(nameof(id));
            return true;
        }

        /// <summary>
        ///     Creates a new user from user details and sends it to the repository that converts it to a stored entity in the storage layer. 
        /// </summary>
        /// <param name="user">User</param>
        /// <returns> int</returns>
        public async Task<int> Create(User user)
        {
            return await _userRepository.Create(Mapper.Map<StoredUser>(user));
        }

        // TODO remove from interface?
        public User Map(User item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}