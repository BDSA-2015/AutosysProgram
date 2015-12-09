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

        /// <summary>
        /// Creates an item from a given Dbset in the <see cref="AutoSysDbModel"/>, e.g. Stored Users.
        /// </summary>
        /// <param name="item">
        /// Entity to create.
        /// </param>
        public virtual int CreateOrUpdate(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Set<T>().Find(item.Id);

                if (entity == null)
                {
                    context.Set<T>().Add(item);
                    context.SaveChanges();
                    return item.Id;
                }

                else
                {
                    context.Set<T>().Attach(item);
                    context.Entry<T>(item).State = EntityState.Modified;
                    context.SaveChanges();
                    return item.Id;
                }

            }

        }

        /// <summary>
        /// Reads a specific item from a given DbSet based on its id. 
        /// </summary>
        /// <param name="id">
        /// Entity with given id. 
        /// </param>
        public virtual T Read(int id)
        {
            using (var context = new AutoSysDbModel())
            {
                return context.Set<T>().Find(id);
            }
        }

        /// <summary>
        /// Reads all stored items in a given DbSet. 
        /// </summary>
        public virtual IEnumerable<T> Read()
        {
            using (var context = new AutoSysDbModel())
            { 
                return context.Set<T>();
            }
        }

        /// <summary>
        /// Updates an item from a given Dbset in the <see cref="AutoSysDbModel"/>, e.g. Stored Users.
        /// </summary>
        /// <param name="item">
        /// Entity to update.
        /// </param>
        public virtual void UpdateIfExists(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Set<T>().Find(item.Id);

                if (entity != null)
                { 
                    context.Set<T>().Attach(item);
                    context.Entry<T>(item).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes an item from a given Dbset in the <see cref="AutoSysDbModel"/>, e.g. Stored Users.
        /// </summary>
        /// <param name="item">
        /// Entity to delete. 
        /// </param>
        public virtual void DeleteIfExists(T item)
        {
            using (var context = new AutoSysDbModel())
            {
                var entity = context.Set<T>().Find(item.Id);

                if (entity != null)
                { 
                context.Set<T>().Remove(item);
                context.SaveChanges();
                }
            }
        }

    }

}
