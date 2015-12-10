using System;
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
        ///     Creates a new storedUser from user details and send it to repository
        /// </summary>
        /// <param name="user">User</param>
        /// <returns> int</returns>
        public Task<int> Create(User user)
        {
            return _userRepository.Create(Mapper.Map<StoredUser>(user));
        }

        Task<User> IAdapter<User>.Read(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<User> IAdapter<User>.Read()
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdapter<User>.UpdateIfExists(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IAdapter<User>.Create(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Reads storedUser and returns a user to the caller.
        /// </summary>
        /// <param name="id"> Id in database</param>
        /// <returns>User</returns>
        public User Read(int id)
        {
            var storedUser = _userRepository.Read(id);
            return Mapper.Map<User>(storedUser);
        }

        /// <summary>
        ///     Returns an Enumerable set of users
        /// </summary>
        /// <returns>Enumerable set of users</returns>
        public IEnumerable<User> Read()
        {
            var storedUsers = _userRepository.Read();

            var userList = Enumerable.ToList(storedUsers.Select(Mapper.Map<User>));
            //Converts storedUsers to user and return as a list
            return userList;
        }

        /// <summary>
        ///     Converts user to storage entity and update it.
        /// </summary>
        /// <param name="user">User object</param>
        public void UpdateIfExists(User user)
        {
            _userRepository.UpdateIfExists(Mapper.Map<StoredUser>(user));
        }

        /// <summary>
        ///     DeleteIfExists given user from database.
        /// </summary>
        /// <param name="user">User Object</param>
        public void DeleteIfExists(User user)
        {
            var toDelete = Read(user.Id);
            if (toDelete == null) throw new NullReferenceException("User does not exist");
            if (user.Name != toDelete.Name && user.MetaData != toDelete.MetaData)
                throw new ArgumentException("User has been updated");
            var storedUserToDelete = Mapper.Map<StoredUser>(toDelete);
            _userRepository.DeleteIfExists(storedUserToDelete.Id);
        }

        public User Map(User item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}