// IRepository.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;

namespace Storage.Repository.Interface
{
    /// <summary>
    /// This interface outlines the CRUD methods that the storage repository class will be able to perform.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : class, IEntity
    {
        int Create(T item);
        T Read(int id);
        IEnumerable<T> Read();
        void UpdateIfExists(T item);
        void DeleteIfExists(T item);
    }
}