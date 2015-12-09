using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Storage.Repository.Interface;

namespace Storage
{

    /// <summary>
    /// This class implements the IRepository interface outlining the CRUD operations to be used in the database. 
    /// These are used specifically on a given Dbcontext set in the AutoSysDbModel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncDbRepository<T> : IAsyncRepository<T> where T : class, IEntity
    {
        private readonly IAutoSysContext _dbContext;

        public AsyncDbRepository(IAutoSysContext context)
        {
            _dbContext = context;
        }

        public virtual async Task<int> Create(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            _dbContext.Attach(item); // Used for mocking
            // _dbContext.Set<T>().Attach(item);
            _dbContext.Add(item); // Used for mocking 
            //_dbContext.Set<T>().Add(item);
            await _dbContext.SaveChangesAsync();
            return item.Id;

        }

        public virtual async Task<T> Read(int id)
        {

            return await _dbContext.Set<T>().FindAsync(id);

        }

        public virtual IQueryable<T> Read()
        {

            return _dbContext.Set<T>().AsQueryable();

        }

        public virtual async Task<bool> Update(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var entity = await _dbContext.Set<T>().FindAsync(item.Id);

            if (entity != null)
            {
                _dbContext.Attach(item); // Used for mocking 
                //_dbContext.Set<T>().Attach(item);
                _dbContext.SetModified(item); // Used for mocking 
                //dbContext.Entry<T>(item).State = EntityState.Modified; 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        public virtual async Task<bool> Delete(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else return false;

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }


}
