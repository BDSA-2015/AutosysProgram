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
    public class AsyncDbRepository<T> : IAsyncRepository<T> where T : class , IEntity
    {

        public virtual async Task<int> Create(T item)
        {
            using (var dbContext = new AutoSysDbModel())
            {
                dbContext.Set<T>().Add(item);
                await dbContext.SaveChangesAsync();
                return item.Id;
            }
        }

        public virtual async Task<T> Read(int id)
        {
            using (var dbContext = new AutoSysDbModel())
            {
                return await dbContext.Set<T>().FindAsync(id);
            }
        }

        public virtual IQueryable<T> Read()
        {
            using (var dbContext = new AutoSysDbModel())
            {
                return dbContext.Set<T>().AsQueryable();
            }
        }

        public virtual async Task<bool> Update(T item)
        {
            using (var dbContext = new AutoSysDbModel())
            {
                var entity = await dbContext.Set<T>().FindAsync(item.Id);

                if (entity != null)
                {
                    dbContext.Set<T>().Attach(item);
                    dbContext.Entry<T>(item).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public virtual async Task<bool> Delete(int id)
        {
            using (var dbContext = new AutoSysDbModel())
            {
                var entity = await dbContext.Set<T>().FindAsync(id);

                if (entity != null)
                {
                    dbContext.Set<T>().Remove(entity);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

    }

}
