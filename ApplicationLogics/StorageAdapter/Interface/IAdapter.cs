// IRepository.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
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
    public interface IAdapter<T,K> : IDisposable
    {
        Task<int> Create(T item);

        Task<T> Read(int id);

        IEnumerable<T> Read();

        Task<bool> UpdateIfExists(T item);

        Task<bool> DeleteIfExists(int id);

        // Adapter specific mapping functionality 
        K Map(T item);
        T Map(K item); 
    }
}