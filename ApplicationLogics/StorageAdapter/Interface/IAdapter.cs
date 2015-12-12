// IRepository.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;

namespace ApplicationLogics.StorageAdapter.Interface
{
    /// <summary>
    ///     This interface outlines the CRUD methods that the storage repository class will be able to perform.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAdapter<T> : IDisposable
    {
        Task<int> Create(T user);

        Task<T> Read(int id);

        IQueryable<T> Read();

        Task<bool> UpdateIfExists(T user);

        Task<bool> DeleteIfExists(int id);

        // Adapter specific functionality 
        T Map(T item); // Convert entities to storage 
    }
}