using System.Collections.Generic;
using System.Data.Entity;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class implements the IRepository interface outlining the CRUD operations to be used in the database. 
    /// These are used specifically on the AutoSysDbModel that implements a DbContext and holds DbSets for all stored model entities. 
    /// This class is inherited by all entity based repositories. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbRepository<T> : IRepository<T> where T : class, IEntity
    {
        
        public virtual int Create(T item)
        {
            using (var context = new AutoSysDbModel())
            { 
                context.Set<T>().Add(item);
                context.SaveChanges();
                return item.Id;
            }

        }

        public virtual T Read(int id)
        {
            using (var context = new AutoSysDbModel())
            {
                return context.Set<T>().Find(id);
            }
        }

        public virtual IEnumerable<T> Read()
        {
            using (var context = new AutoSysDbModel())
            { 
                return context.Set<T>();
            }
        }

        public virtual void Update(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                context.Set<T>().Attach(item);
                context.Entry<T>(item).State = EntityState.Modified;
            }
        }

        public virtual void Delete(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
        }

    }

}
