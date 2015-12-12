//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Storage.Models;
//using Storage.Repository.Interface;

//namespace Storage.Repository
//{
//    public class OldSyncUserRepository : IRepository<StoredUser> // Before : DbRepository<StoredUser> 
//    {
//        public int Create(StoredUser user)
//        {
//            using (var context = new AutoSysDbModel())
//            {
//                if (user == null) throw new ArgumentNullException(nameof(user));

//                context.Users.Add(user);
//                context.SaveChanges();
//                return user.Id;

//            }
//        }

//        public StoredUser Read(int id)
//        {
//            using (var context = new AutoSysDbModel())
//            {
//                return context.Users.Find(id);
//            }
//        }

//        public IEnumerable<StoredUser> Read()
//        {
//            using (var context = new AutoSysDbModel())
//            {
//                return context.Users.AsEnumerable();
//            }
//        }

//        public void UpdateIfExists(StoredUser user)
//        {
//            using (var context = new AutoSysDbModel())
//            {
//                var entity = context.Users.Find(user.Id);

//                if (entity != null)
//                {
//                    entity.Name = user.Name;
//                    entity.MetaData = user.MetaData;
//                    context.SaveChanges();
//                }
//            }
//        }

//        public void DeleteIfExists(StoredUser user)
//        {
//            using (var context = new AutoSysDbModel())
//            {
//                var entity = context.Users.Find(user.Id);

//                if (entity != null)
//                {
//                    context.Users.Remove(entity);
//                    context.SaveChanges();
//                }
//            }
//        }

//    }

//}
