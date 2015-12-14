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
    ///     This class is responsible for converting user to storedusers and call propriate
    ///     database operations
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
        ///     Reads storedUser and returns a user to the caller.
        /// </summary>
        /// <param name="id"> Id in database</param>
        /// <returns>User</returns>
        public async Task<User> Read(int id)
        {
            var user = Mapper.Map<User>(await _userRepository.Read(id));
            return user;
        }

        /// <summary>
        ///     Returns an IQueryable set of users
        /// </summary>
        /// <returns>IQueryable set of users</returns>
        public IQueryable<User> Read()
        {
            var storedUsers = _userRepository.Read();
            return Queryable.AsQueryable(storedUsers.Select(Mapper.Map<User>));
            ;
        }

        /// <summary>
        ///     Converts user to storage entity and update it.
        /// </summary>
        /// <param name="user">User object</param>
        public async Task<bool> UpdateIfExists(User user)
        {
            return await _userRepository.UpdateIfExists(Mapper.Map<StoredUser>(user));
        }

        /// <summary>
        ///     DeleteIfExists given user from database.
        /// </summary>
        /// <param name="id">id of user</param>
        public async Task<bool> DeleteIfExists(int id)
        {
            var result = await _userRepository.DeleteIfExists(id);
            if (!result) throw new NullReferenceException(nameof(id));
            return true;
        }

        /// <summary>
        ///     Creates a new storedUser from user details and send it to repository
        /// </summary>
        /// <param name="user">User</param>
        /// <returns> int</returns>
        public async Task<int> Create(User user)
        {
            return await _userRepository.Create(Mapper.Map<StoredUser>(user));
        }


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