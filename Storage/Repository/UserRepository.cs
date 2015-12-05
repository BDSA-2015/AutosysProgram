using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store users in the database. 
    /// </summary>
    public class UserRepository : IRepository<StoredUser> 
    {
        public int Create(StoredUser item)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredUser item)
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

        public void Update(StoredUser item)
        {
            throw new NotImplementedException();
        }
    }
}
