using System;
using System.Collections.Generic;
using Storage.Models;
using StorageTests;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store users in the database. 
    /// </summary>
    public class UserRepository : IRepository<StoredUser>
    {

        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

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
