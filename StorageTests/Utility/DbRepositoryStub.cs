using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Storage;
using Storage.Repository.Interface;

namespace StorageTests.Utility
{

    /// <summary>
    /// This class implements the IRepository interface outlining the CRUD operations to be used in the database. 
    /// These are used specifically on a given Dbcontext set in the AutoSysDbModel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbRepositoryStub<T> : IRepository<T> where T : class, IEntity
    {

        private readonly IDbContext _context;

        public DbRepositoryStub(IDbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> Create(T item)
        {
            using (_context)
            {
                _context.Set<T>().Add(item);
                await _context.SaveChangesAsync();
                return item.Id;
            }
        }

        public virtual async Task<T> Read(int id)
        {
            using (_context)
            {
                return await _context.Set<T>().FindAsync(id);
            }
        }

        public virtual IQueryable Read()
        {
            using (_context)
            {
                return _context.Set<T>().AsQueryable();
            }
        }

        public virtual async Task<bool> Update(T item)
        {
            using (_context)
            {
                var entity = await _context.Set<T>().FindAsync(item.Id);

                if (entity != null)
                {
                    _context.Set<T>().Attach(item);
                    _context.Entry<T>(item).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

        public virtual async Task<bool> Delete(T item)
        {
            using (_context)
            {
                var entity = await _context.Set<T>().FindAsync(item.Id);

                if (entity != null)
                {
                    _context.Set<T>().Remove(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else return false;
            }
        }

    }

}
