using System;
using ApplicationLogics.Repository;
using ConsoleApplication1.Repository;

namespace ApplicationLogics.UserManagement
{
    public class UserHandler
    {
        private readonly UserValidator _userValidator;
        private IStorage<IEntity> _storage;

        public UserHandler(IStorage<IEntity> storage)
        {
            _userValidator = new UserValidator();
            _storage = storage;
        }


        public bool ValidateUser(User user)
        {
            return _userValidator.validateUser(user);
        }

        public void CreateUser(string name)
        {
            throw new NotImplementedException();
        }

        public void EditUser(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User ReadUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}