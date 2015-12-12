using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.UserManagement.Stub
{
    /// <summary>
    ///     This class is a stub of a repository used for testing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryStub<T> : IRepository<T> where T : class, IEntity
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

        Task<T> IRepository<T>.Read(int id)
        {
            throw new System.NotImplementedException();
        }

        IQueryable<T> IRepository<T>.Read()
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepository<T>.UpdateIfExists(T user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteIfExists(T item)
        {
            _database.Remove(item.Id);
        }

        public IEnumerable<T> Read()
        {
            return _database.ToList() as IEnumerable<T>;
        }

        Task<int> IRepository<T>.Create(T user)
        {
            throw new System.NotImplementedException();
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

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}