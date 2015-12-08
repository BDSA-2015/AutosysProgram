using System.Collections.Generic;
using System.Linq;
using Storage;
using Storage.Models;
using Storage.Repository.Interface;

namespace StorageTests.Utility
{
    public class UserRepositoryStub : IRepository<StoredUser> // Before : DbRepository<StoredUser> 
    {

        private AutoSysDbModel _context;

        public UserRepositoryStub(AutoSysDbModel context)
        {
            _context = context;
        }

        public int CreateOrUpdate(StoredUser user)
        {
            using (_context = new AutoSysDbModel())
            {
                var entity = _context.Users.Find(user.Id);

                if (entity == null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return user.Id;
                }
                else
                {
                    entity.Name = user.Name;
                    entity.MetaData = user.MetaData;
                    _context.SaveChanges();
                    return user.Id;
                }

            }
        }

        public StoredUser Read(int id)
        {
            using (_context = new AutoSysDbModel())
            {
                return _context.Users.Find(id);
            }
        }

        public IEnumerable<StoredUser> Read()
        {
            using (_context = new AutoSysDbModel())
            {
                return _context.Users.AsEnumerable();
            }
        }

        public void UpdateIfExists(StoredUser user)
        {
            using (_context = new AutoSysDbModel())
            {
                var entity = _context.Users.Find(user.Id);

                if (entity != null)
                {
                    entity.Name = user.Name;
                    entity.MetaData = user.MetaData;
                    _context.SaveChanges();
                }
            }
        }

        public void DeleteIfExists(StoredUser user)
        {
            using (_context = new AutoSysDbModel())
            {
                var entity = _context.Users.Find(user.Id);

                if (entity != null)
                {
                    _context.Users.Remove(entity);
                    _context.SaveChanges();
                }
            }
        }
    }

}
