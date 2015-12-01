// IRepository.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;

namespace ApplicationLogics.StorageFasade
{
    /// <summary>
    /// This interface outlines the CRUD methods that the storage repository class will be able to perform.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFasade<T> 
    {
        int Create(T item);
        T Read(int id);
        IEnumerable<T> Read();
        void Update(T item);
        void Delete(T item);

        // Free to add functionality specific 
    }
}