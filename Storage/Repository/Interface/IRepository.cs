// IRepository.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.Repository.Interface
{
    /// <summary>
    /// This interface outlines the CRUD methods that the storage repository class will be able to perform.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IEntity
    {
        Task<int> Create(T item);
        Task<T> Read(int id);
        IQueryable Read();
        Task<bool> Update(T item);
        Task<bool> Delete(T item);
    }
}