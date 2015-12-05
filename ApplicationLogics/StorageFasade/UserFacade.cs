using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.StorageFasade
{
    public class UserFacade : IFacade<User>
    {

        public int Create(User item)
        {
            throw new NotImplementedException();
        }

        public User Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }
    }
}
