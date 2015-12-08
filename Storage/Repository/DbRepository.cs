using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<int> Create(T user)
        {
            using (_dbContext)
            {
                    _dbContext.Set<T>().Add(user);
                    await _dbContext.SaveChangesAsync();
                    return user.Id;
            }
        }

        public async Task<T> Read(int id)
        {
            using (_dbContext)
            { 
                return await _dbContext.Set<T>().FindAsync(id);
            }
        }

        public IQueryable Read()
        {
            using (_dbContext)
            {
                return _dbContext.Set<T>().AsQueryable();
            }
        }

        public async Task<bool> Update(T user)
        {
            using (_dbContext)
            {
                var entity = await _dbContext.Set<T>().FindAsync(user.Id);

                if (entity != null)
                {
                    _dbContext.Set<T>().Attach(user);
                    _dbContext.Entry<T>(user).State = EntityState.Modified;
                    return true;
                }
                else return false;
            }
        }

        public async Task<bool> Delete(T user)
        {
            using (_dbContext)
            {
                var entity = await _dbContext.Set<T>().FindAsync(user.Id);

                if (entity != null)
                {
                    _dbContext.Set<T>().Remove(user);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }

}
