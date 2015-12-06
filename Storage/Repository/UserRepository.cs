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

        public async Task<bool> Delete(int userId)
        {
            using (_context)
            {
                var userToDelete = await _context.Users.FindAsync(userId);

                if (userToDelete != null)
                {
                    _context.Users.Remove(userToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public IQueryable Read()
        {
            using (_context)
            {
                return _context.Users.AsQueryable();
            }
        }

        public async Task<StoredUser> Read(int userId)
        {
            using (_context)
            {
                var users = from u in _context.Users
                    where u.Id == userId
                    select new StoredUser
                    {
                        Id = u.Id,
                        Name = u.Name,
                        MetaData = u.MetaData
                    };
                return await users.FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Update(StoredUser user)
        {
            using (_context)
            { 
                var userToUpdate = await _context.Users.FindAsync(user.Id);

                if (userToUpdate != null)
                {
                    userToUpdate.Name = user.Name;
                    userToUpdate.MetaData = user.MetaData;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
                
                /* Entry not mockable
                _context.Users.Attach(user);
                var entry = _context.Entry(user);
                entry.State = EntityState.Modified;
                */
            }

        }

    }

}
