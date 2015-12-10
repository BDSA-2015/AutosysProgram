using System;
using System.Collections.Generic;
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

        public int Create(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            var storedPaper = Mapper.Map<StoredPaper>(item);
            return _papers.Create(storedPaper);
        }

        public void Delete(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            var storedPaper = Mapper.Map<StoredPaper>(item);
            _papers.DeleteIfExists(storedPaper);
        }

        public IEnumerable<Paper> Read()
        {
            foreach (var storedPaper in _papers.Read())
            {
                yield return Mapper.Map<Paper>(storedPaper);
            }
        }

        public Paper Read(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The given id must be 0 or greater");
            }

            return Mapper.Map<Paper>(_papers.Read(id));
        }

        public void Update(Paper item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }

            _papers.UpdateIfExists(Mapper.Map<StoredPaper>(item));
        }
    }
}