using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using Storage.Entities;

namespace ApplicationLogics.StorageFasade
{
    public class UserFasade : IFasade<User>
    {
        private readonly IRepository<StoredUser> _userRepository; 

        public UserFasade(IRepository<StoredUser> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Creates a new storedUser from user details and send it to repository
        /// </summary>
        /// <param name="user">User</param>
        /// <returns> int</returns>
        public int Create(User user)
        {
            return _userRepository.Create(ConvertUser(user));
        }

        /// <summary>
        /// Reads storedUser and returns a user to the caller.
        /// </summary>
        /// <param name="id"> Id in database</param>
        /// <returns>User</returns>
        public User Read(int id)
        {
            var storedUser = _userRepository.Read(id);
            return ConvertUser(storedUser);
        }

        /// <summary>
        /// Returns an Enumable set of users
        /// </summary>
        /// <returns>Enumerable set of users</returns>
        public IEnumerable<User> Read()
        {
           var storedUsers = _userRepository.Read();
           var userList = storedUsers.Select(ConvertUser).ToList(); //Converts storedUsers to user and return as a list
           return userList;
        }

        public void Update(User user)
        {
            //TODO How to retrieve specific user from database without any ID?
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            //TODO How to retrieve specific user from database without any ID?
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts User to StoredUser
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>User</returns>
        private StoredUser ConvertUser(User user)
        {
            return new StoredUser() { Name = user.Name, MetaData = user.Metadata };
        }

        /// <summary>
        /// Convert storedUser to user
        /// </summary>
        /// <param name="user">Stored User</param>
        /// <returns>User</returns>
        private User ConvertUser(StoredUser user)
        {
            return new User() { Name = user.Name, Metadata = user.MetaData};
        }
    }
}
