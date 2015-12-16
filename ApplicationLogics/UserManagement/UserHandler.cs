// UserHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement.Entities;
using ApplicationLogics.UserManagement.Utils;

namespace ApplicationLogics.UserManagement
{
    /// <summary>
    ///     This class is responsible for user operations
    /// </summary>
    public class UserHandler
    {
        private readonly IAdapter<User> _storage;

        public UserHandler(IAdapter<User> storage)
        {
            _storage = storage;
        }


        /// <summary>
        ///     Validates if a user exists in database.
        /// </summary>
        /// <param name="id">user Id</param>
        /// <returns>bool of user existence</returns>
        public bool ValidateUser(int id)
        {
            return UserValidator.ValidateExistence(id, _storage);
        }

        /// <summary>
        ///     Creates a user with information from a userDTo
        /// </summary>
        /// <param name="user">User object</param>
        public async Task<int> Create(User user)
        {
            if (user == null)
                throw new ArgumentException("User is null");
            if (!UserValidator.ValidateEnteredUserInformation(user))
                throw new ArgumentException("Input may not be null, whitespace or empty");

            return await _storage.Create(user);
        }

        /// <summary>
        ///     Edit and update an existing user
        /// </summary>
        /// <param name="oldId">id of user to update</param>
        /// <param name="user">User object</param>
        public async Task<bool> Update(int oldId, User user)
        {
            if (!UserValidator.ValidateId(oldId))
                throw new ArgumentException("Id is not valid");
            if (!UserValidator.ValidateEnteredUserInformation(user))
                throw new ArgumentException("User data is invalid");
            if (!UserValidator.ValidateExistence(oldId, _storage))
                throw new ArgumentException("User does not exist");

            return await _storage.UpdateIfExists(user);
        }

        /// <summary>
        ///     DeleteIfExists an existing user
        /// </summary>
        /// <param name="id">id of user to delete.</param>
        public async Task<bool> Delete(int id)
        {
            if (!UserValidator.ValidateId(id))
                throw new ArgumentException("Id is not valid");
             
            return await _storage.DeleteIfExists(id);
        }

        /// <summary>
        ///     Get a user from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> Read(int id)
        {
            if (!UserValidator.ValidateId(id))
                throw new ArgumentException("Id is not valid");

            return await _storage.Read(id);
        }

        /// <summary>
        ///     Get every user from the database.
        /// </summary>
        /// <returns>All users</returns>
        public IQueryable<User> GetAll()
        {
            return _storage.Read();
        }
    }
}