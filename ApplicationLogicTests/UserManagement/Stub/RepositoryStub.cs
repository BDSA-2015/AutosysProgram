using System.Collections.Generic;
using System.Linq;
using Storage.Repository;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.UserManagement.Stub
{
    /// <summary>
    /// This class is a stub of a repository used for testing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryStub<T> : IRepository<T> where T : IEntity
    {
        private readonly Dictionary<int, T> _database;
        private int _id;

        public RepositoryStub()
        {
            _id = 0;
            _database = new Dictionary<int, T>();
        }

        public int Create(T item)
        {
            item.Id = _id;
            _id++;

            _database.Add(item.Id, item);
            return item.Id;
        }

        public void DeleteIfExists(T item)
        {
            _database.Remove(item.Id);
        }

        public IEnumerable<T> Read()
        {
            return _database.ToList() as IEnumerable<T>;
        }

        public T Read(int id)
        {
            
            return _database[id];
        }

        public void UpdateIfExists(T item)
        {
            _database.Remove(item.Id);
            _database.Add(item.Id, item);
        }
    }
}