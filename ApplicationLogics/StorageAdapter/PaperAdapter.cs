using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageAdapter.Interface;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    public class PaperAdapter : IAdapter<Paper>
    {
        //TODO Write purpose of class
        private readonly IRepository<StoredPaper> _papers;

        public PaperAdapter(IRepository<StoredPaper> papers)
        {
            _papers = papers;
        }

        public Task<int> Create(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            var storedPaper = Mapper.Map<StoredPaper>(item);
            return _papers.Create(storedPaper);
        }

        Task<Paper> IAdapter<Paper>.Read(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<Paper> IAdapter<Paper>.Read()
        {
            throw new NotImplementedException();
        }

        Task<bool> IAdapter<Paper>.UpdateIfExists(Paper user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteIfExists(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            var storedPaper = Mapper.Map<StoredPaper>(item);
            _papers.DeleteIfExists(storedPaper.Id);
        }

        public Paper Map(Paper item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Paper> Read()
        {
            foreach (var storedPaper in _papers.Read())
            {
                yield return Mapper.Map<Paper>(storedPaper);
            }
        }

        Task<int> IAdapter<Paper>.Create(Paper user)
        {
            throw new NotImplementedException();
        }

        public Paper Read(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The given id must be 0 or greater");
            }

            return Mapper.Map<Paper>(_papers.Read(id));
        }

        public void UpdateIfExists(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }

            _papers.UpdateIfExists(Mapper.Map<StoredPaper>(item));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}