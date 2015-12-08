using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{
    
    public class UserRepository : DbRepository<StoredUser>
    {
        
    }
    
    
    /// <summary>
    /// This class outlines the CRUD operations used to store users in the database. 
    /// </summary>
    //public class UserRepository : IRepository<StoredUser>
    //{

        
    //    private AutoSysDbModel _context;

    //    public UserRepository(){}

    //    public async Task<int> Create(StoredUser item)
    //    {
    //        using (_context = new AutoSysDbModel())
    //        { 
    //            _context.Users.Add(item);
    //            await _context.SaveChangesAsync();
    //            return item.Id;
    //        }
    //    }

    //    public async Task<bool> Delete(StoredUser item)
    //    {
    //        using (_context = new AutoSysDbModel())
    //        {
    //            var userToDelete = await _context.Users.FindAsync(item);

    //            if (userToDelete != null)
    //            {
    //                _context.Users.Remove(userToDelete);
    //                await _context.SaveChangesAsync();
    //                return true;
    //            }
    //            else return false;
    //        }
    //    }

    //    public IQueryable Read()
    //    {
    //        using (_context = new AutoSysDbModel())
    //        {
    //            return _context.Users.AsQueryable();
    //        }
    //    }

    //    public async Task<StoredUser> Read(int userId)
    //    {
    //        using (_context = new AutoSysDbModel())
    //        {
    //            var users = from u in _context.Users
    //                where u.Id == userId
    //                select new StoredUser
    //                {
    //                    Id = u.Id,
    //                    Name = u.Name,
    //                    MetaData = u.MetaData
    //                };
    //            return await users.FirstOrDefaultAsync();
    //        }
    //    }

    //    public async Task<bool> Update(StoredUser item)
    //    {
    //        using (_context = new AutoSysDbModel())
    //        { 
    //            var userToUpdate = await _context.Users.FindAsync(item.Id);

    //            if (userToUpdate == null)
    //            {
    //                return false;
    //            }

    //            userToUpdate.Name = item.Name;
    //            userToUpdate.MetaData = item.MetaData;
    //            await _context.SaveChangesAsync();

    //            return true;

    //            /* Entry not mockable
    //            _context.Users.Attach(user);
    //            var entry = _context.Entry(user);
    //            entry.State = EntityState.Modified;
    //            */
    //        }
    
    //    }
        
       
    //}
    

}
