// UserHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement.Entities;
using ApplicationLogics.UserManagement.Utils;

namespace ApplicationLogics.UserManagement
{
    public class UserHandler
    {
        private readonly IFasade<User> _storage;

        public UserHandler(IFasade<User> storage)
        {
            _storage = storage;
        }


        /// <summary>
        /// Validates if a user is valid.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>a boolean if a user is valid</returns>
        public bool ValidateUser(int userId)
        {
            return UserValidator.ValidateExistence(userId, _storage);
        }

        /// <summary>
        /// Creates a user with information from a userDTo
        /// </summary>
        /// <param name="userDto">userDto from webapi</param>
        public void CreateUser(SystematicStudyService.Models.User userDto)
        {
            var user = new User();//TODO User Mapper to convert user
            if (!UserValidator.ValidateEnteredUserInformation(user))
                throw new ArgumentException("Input may not be null, whitespace or empty");

            _storage.Create(user);
        }

        /// <summary>
        /// Edit and update an existing user
        /// </summary>
        /// <param name="id">id of user to update</param>
        public void EditUser(int id) //TODO ID's are not used in FACADE AND REPO. This may need to be changed
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="id">id of user to delete.</param>
        public void DeleteUser(int id) //TODO ID's are not used in FACADE AND REPO. This may need to be changed
        {
            if (id < 0)
                throw new ArgumentException("Id may not be less than 0");

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