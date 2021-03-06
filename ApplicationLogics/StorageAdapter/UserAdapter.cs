﻿using System;
using System.Collections.Generic;
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
    public class UserAdapter : IAdapter<User, StoredUser>
    {
        private readonly IRepository<StoredUser> _userRepository;

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
            return Mapper.Map<User>(await _userRepository.Read(id));
        }

        /// <summary>
        ///     Returns all users. 
        /// </summary>
        /// <returns>
        ///     A set of users. 
        /// </returns>
        public IEnumerable<User> Read()
        {
            throw new NotImplementedException();
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

        public StoredUser Map(User item)
        {
            throw new NotImplementedException();
        }

        public User Map(StoredUser item)
        {
            throw new NotImplementedException();
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

        public void Dispose()
        {
            _userRepository.Dispose();
        }
    }
}