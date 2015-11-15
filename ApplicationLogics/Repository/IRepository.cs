using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.Repository
{

    /// <summary>
    /// This interface outlines the CRUD methods that the storage repository class will be able to perform.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        int Create(T item);
        T Read(int id);
        IEnumerable<T> Read();
        void Update(T item);
        void Delete(T item);
    }
}
