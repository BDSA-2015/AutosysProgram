using System.Collections.Generic;
using System.Data.Entity;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class implements the IRepository interface outlining the CRUD operations to be used in the database. 
    /// These are used specifically on a given Dbcontext set in the AutoSysDbModel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext _dbContext;

        public DbRepository(DbContext context)
        {
            _dbContext = context;
        }

        public int Create(T user)
        {
            _dbContext.Set<T>().Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public T Read(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> Read()
        {
            return _dbContext.Set<T>();
        }

        public void Update(T updatedUser)
        {
            _dbContext.Set<T>().Attach(updatedUser);
            _dbContext.Entry<T>(updatedUser).State = EntityState.Modified;
        }

        public void Delete(T user)
        {
            _dbContext.Set<T>().Remove(user);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }

}
