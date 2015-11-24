﻿// UserHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using ApplicationLogics.Repository;

namespace ApplicationLogics.UserManagement
{
    public class UserHandler
    {
        private readonly UserValidator _userValidator;
        private IRepository<IEntity> _storage;

        public UserHandler(IRepository<IEntity> storage)
        {
            _userValidator = new UserValidator();
            _storage = storage;
        }


        public bool ValidateUser(User user)
        {
            return _userValidator.ValidateUser(user);
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