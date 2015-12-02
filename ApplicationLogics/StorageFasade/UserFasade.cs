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
            return _userRepository.Create(AutoMapper.Mapper.Map<StoredUser>(user));
        }

        /// <summary>
        /// Reads storedUser and returns a user to the caller.
        /// </summary>
        /// <param name="id"> Id in database</param>
        /// <returns>User</returns>
        public User Read(int id)
        {
            var storedUser = _userRepository.Read(id);
            return AutoMapper.Mapper.Map<User>(storedUser);
        }

        /// <summary>
        /// Returns an Enumable set of users
        /// </summary>
        /// <returns>Enumerable set of users</returns>
        public IEnumerable<User> Read()
        {
           var storedUsers = _userRepository.Read();

           var userList = storedUsers.Select(AutoMapper.Mapper.Map<User>).ToList(); //Converts storedUsers to user and return as a list
           return userList;
        }

        public void Update(User user)
        {
            //TODO How to retrieve specific user from database without any ID?
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            var toDelete = Read(user.Id);
            if(toDelete == null) throw new NullReferenceException("User does not exist");
            if (!user.Equals(toDelete)) throw new ArgumentException("User has been updated");
            var storedUserToDelete = AutoMapper.Mapper.Map<StoredUser>(toDelete);
            _userRepository.Delete(storedUserToDelete);

        }
    }
}
