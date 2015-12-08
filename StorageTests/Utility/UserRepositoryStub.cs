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
            using (var _context = new AutoSysDbModel())
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
            using (var context = new AutoSysDbModel())
            {
                return context.Users.Find(id);
            }
        }

        public IEnumerable<StoredUser> Read()
        {
            using (var context = new AutoSysDbModel())
            {
                return context.Users.AsEnumerable();
            }
        }

        public void UpdateIfExists(StoredUser user)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Users.Find(user.Id);

                if (entity != null)
                {
                    entity.Name = user.Name;
                    entity.MetaData = user.MetaData;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteIfExists(StoredUser user)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Users.Find(user.Id);

                if (entity != null)
                {
                    context.Users.Remove(entity);
                    context.SaveChanges();
                }
            }
        }
    }

}
