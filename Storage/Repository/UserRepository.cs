using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{
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
