// UserHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using ApplicationLogics.Repository;

namespace ApplicationLogics.UserManagement
{
    public class UserHandler
    {
        private readonly IRepository<User> _storage;
        private readonly UserValidator _userValidator;

        public UserHandler(IRepository<User> storage)
        {
            _userValidator = new UserValidator();
            _storage = storage;

            



        }


        public bool ValidateUser(int userId)
        {
            return _userValidator.ValidateUser(userId, _storage);
        }

        public void CreateUser(string name, string metadata)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(metadata))
                throw new ArgumentException("Input may not be null, whitespace or empty");

            var user = new User() {Name = name.Trim(), Metadata = metadata.Trim()};
            _storage.Create(user);

        }

        public void EditUser(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            if(id < 0 )
                throw  new ArgumentException("Id may not be less than 0");

            var userToDelete =_storage.Read(id);
            if (userToDelete != null)
            {
                _storage.Delete(userToDelete);
            }
            else throw new NullReferenceException("Specified user does not exist.");
        }

        public User ReadUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}