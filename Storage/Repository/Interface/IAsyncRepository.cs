using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Repository.Interface
{

    /// <summary>
    /// This interface outlines the basic crud operations used for async repositories, e.g. <see cref="AsyncDbRepository"/>.
    /// </summary>
    /// <typeparam name="T">
    /// Entity written in database.
    /// </typeparam>
    public interface IAsyncRepository<T> where T : class, IEntity
    {
        Task<int> Create(T item);

        Task<T> Read(int id);

        IQueryable<T> Read();

        Task<bool> Update(T item);

        Task<bool> Delete(int id);
    }

}
