//using System.Collections.Generic;
//using System.Linq;
//using Storage;
//using Storage.Models;
//using Storage.Repository.Interface;

//namespace StorageTests.Utility
//{

//    /// <summary>
//    /// This is a test stub of the generic DbRepository in storage used to mock the repository with an interface instead of a concrete DbContext. 
//    /// This is no longer used. Instead created interface to mock DbContext and inject in ctor in repository implementing IDisposable in all places used. 
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    public class UserRepositoryStub : IRepository<StoredUser> // Before : DbRepository<StoredUser> 
//    {

//        private IUserContext _context;

//        public UserRepositoryStub(IUserContext context)
//        {
//            _context = context;
//        }

//        public int Create(StoredUser user)
//        {
//            using (_context)
//            {
//                var entity = _context.Users.Find(user.Id);

//                if (entity == null)
//                {
//                    _context.Users.Add(user);
//                    _context.SaveChanges();
//                    return user.Id;
//                }
//                else
//                {
//                    entity.Name = user.Name;
//                    entity.MetaData = user.MetaData;
//                    _context.SaveChanges();
//                    return user.Id;
//                }

//            }
//        }

//        public StoredUser Read(int id)
//        {
//            using (_context)
//            {
//                return _context.Users.Find(id);
//            }
//        }

//        public IEnumerable<StoredUser> Read()
//        {
//            using (_context)
//            {
//                return _context.Users.AsEnumerable();
//            }
//        }

//        public void UpdateIfExists(StoredUser user)
//        {
//            using (_context)
//            {
//                var entity = _context.Users.Find(user.Id);

//                if (entity != null)
//                {
//                    entity.Name = user.Name;
//                    entity.MetaData = user.MetaData;
//                    _context.SaveChanges();
//                }
//            }
//        }

//        public void DeleteIfExists(StoredUser user)
//        {
//            using (_context)
//            {
//                var entity = _context.Users.Find(user.Id);

//                if (entity != null)
//                {
//                    _context.Users.Remove(entity);
//                    _context.SaveChanges();
//                }
//            }
//        }
//    }

//}
