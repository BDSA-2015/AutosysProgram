using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store Studies in the database. 
    /// </summary>
    public class StudyRepository : IRepository<StoredStudy>
    {
        public Task<int> Create(StoredStudy user)
        {
            throw new NotImplementedException();
        }

        public Task<StoredStudy> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(StoredStudy user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(StoredStudy user)
        {
            throw new NotImplementedException();
        }
    }

}
