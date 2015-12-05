// UserHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement.Entities;
using ApplicationLogics.UserManagement.Utils;

namespace ApplicationLogics.UserManagement
{
    /// <summary>
    /// This class is responsible for user operations
    /// </summary>
    public class UserHandler
    {
        private readonly IFacade<User> _storage;

        public UserHandler(IFacade<User> storage)
        {
            _storage = storage;
        }


        

        /// <summary>
        /// Creates a user with information from a userDTo
        /// </summary>
        /// <param name="user">User object</param>
        public int CreateUser(User user)
        {
            if(user == null) 
                throw new ArgumentException("User is null");
            if (!UserValidator.ValidateEnteredUserInformation(user))
                throw new ArgumentException("Input may not be null, whitespace or empty");

            return _storage.Create(user);
        }

        /// <summary>
        /// Edit and update an existing user
        /// </summary>
        /// <param name="oldId">id of user to update</param>
        /// <param name="user">User object</param>
        public void EditUser(int oldId, User user)
        {
            if(!UserValidator.ValidateId(oldId))
                throw new ArgumentException("Id is not valid");
            if (!UserValidator.ValidateEnteredUserInformation(user))
                throw new ArgumentException("User data is invalid");
            if (!UserValidator.ValidateExistence(oldId, _storage))
                throw new ArgumentException("User does not exist");

            _storage.Update(user);
        }

        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="id">id of user to delete.</param>
        public void DeleteUser(int id)
        {

            if (!UserValidator.ValidateExistence(id, _storage))
                throw new ArgumentException("User does not exist");

            var userToDelete = _storage.Read(id);
            if (userToDelete != null)
            {
                _storage.Delete(userToDelete);
            }
            else throw new NullReferenceException("Specified user does not exist.");
        }

        /// <summary>
        /// Get a user from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User ReadUser(int id)
        {
            if (!UserValidator.ValidateId(id))
                throw new ArgumentException("Id is not valid");

            return _storage.Read(id);
        }

        /// <summary>
        /// Get every user from the database.
        /// </summary>
        /// <returns>All users</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return _storage.Read();
        }
    }
}