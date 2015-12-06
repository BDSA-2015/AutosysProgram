using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store users in the database. 
    /// </summary>
    public class UserRepository : IRepository<StoredUser>
    {

        /*
        private readonly IUserContext _context;

        // Used for mocking 
        public UserRepository(IUserContext _context)
        {
            _context = _context;
        }
        */

        private readonly AutoSysDbModel _context;

        public UserRepository(AutoSysDbModel context)
        {
            _context = context;
        }

        public UserRepository(){}

        public async Task<int> Create(StoredUser user)
        {
            using (_context)
            { 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }

        public void Delete(StoredUser user)
        {
            using (_context)
            { 
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<StoredUser> Read()
        {
            using (_context)
            { 
                return _context.Users.ToList();
            }
        }

        public StoredUser Read(int id)
        {
            using (_context)
            { 
                return _context.Users.Find(1);
            }
        }

        public void Update(StoredUser updatedUser)
        {
            using (_context)
            { 
                var entity = _context.Users.Find(updatedUser.Id);

                if (entity != null)
                {
                entity.Name = updatedUser.Name;
                entity.MetaData = updatedUser.MetaData;
                }

                _context.SaveChanges();
                /* Entry not mockable
                _context.Users.Attach(updatedUser);
                var entry = _context.Entry(updatedUser);
                entry.State = EntityState.Modified;
                */
            }
        }

    }

}
