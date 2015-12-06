using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store users in the database. 
    /// </summary>
    public class UserRepository : IRepository<StoredUser>
    {

        private readonly IUserContext _context;

        // Used for mocking 
        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public UserRepository(){}

        public int Create(StoredUser user)
        {
            using (var context = new AutoSysDbModel())
            { 
                context.Users.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }

        public void Delete(StoredUser user)
        {
            using (var context = new AutoSysDbModel())
            { 
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<StoredUser> Read()
        {
            using (var context = new AutoSysDbModel())
            { 
                return context.Users.ToList();
            }
        }

        public StoredUser Read(int id)
        {
            using (var context = new AutoSysDbModel())
            { 
                return context.Users.Find(1);
            }
        }

        public void Update(StoredUser updatedUser)
        {
            using (var context = new AutoSysDbModel())
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

}
