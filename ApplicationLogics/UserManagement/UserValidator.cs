using System;
using ApplicationLogics.StorageFasade;

namespace ApplicationLogics.UserManagement
{
    public class UserValidator
    {


        public bool ValidateUser(int userId, IFasade<User> userFasade )
        {
            return userFasade.Read(userId) != null;
        }

        public bool ValidateEnteredUserInformation(string name, string metadata)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(metadata);
        }
    }
}