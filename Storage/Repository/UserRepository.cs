using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public int Create(StoredUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void Delete(StoredUser user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<StoredUser> Read()
        {
            return _context.Users.ToList();
        }

        public StoredUser Read(int id)
        {
            return _context.Users.Find(1);
        }

        public void Update(StoredUser updatedUser)
        {
            var entity = _context.Users.Find(updatedUser.Id);

            if (entity != null)
            {
                entity.Name = updatedUser.Name;
                entity.MetaData = updatedUser.MetaData;
            }

            /* Entry not mockable
            _context.Users.Attach(updatedUser);
            var entry = _context.Entry(updatedUser);
            entry.State = EntityState.Modified;
            */ 
  
            _context.SaveChanges();
        }
    }
}
