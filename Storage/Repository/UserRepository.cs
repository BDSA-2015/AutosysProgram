using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{
    public class UserRepository : IRepository<StoredUser> 
    {
        public int CreateOrUpdate(StoredUser item)
        {
            throw new NotImplementedException();
        }

        public void DeleteIfExists(StoredUser item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoredUser> Read()
        {
            throw new NotImplementedException();
        }

        public StoredUser Read(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateIfExists(StoredUser item)
        {
            throw new NotImplementedException();
        }
    }
}
