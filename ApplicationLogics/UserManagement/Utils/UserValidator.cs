// UserValidator.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement.Entities;
using Storage.Models;

namespace ApplicationLogics.UserManagement.Utils
{
    public class UserValidator
    {
        /// <summary>
        ///     Check if a specific user exists
        /// </summary>
        /// <param name="userId">user to find</param>
        /// <param name="userFasade">StorageLocation</param>
        /// <returns>user's existence</returns>
        internal static bool ValidateExistence(int userId, IAdapter<User, StoredUser> userFasade)
        {
            return userFasade.Read(userId) != null;
        }

        /// <summary>
        ///     Validate user information
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>validation of user information</returns>
        internal static bool ValidateEnteredUserInformation(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Name) && !string.IsNullOrWhiteSpace(user.MetaData);
        }

        internal static bool ValidateId(int id)
        {
            return id >= 0;
        }
    }
}