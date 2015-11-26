using System;
using ApplicationLogics.Repository;

namespace ApplicationLogics.UserManagement
{
    public class UserValidator
    {


        public bool ValidateUser(int userId, IRepository<User> repository )
        {
            return repository.Read(userId) != null;
        }
    }
}