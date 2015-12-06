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
        public int Create(StoredStudy user)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredStudy user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoredStudy> Read()
        {
            throw new NotImplementedException();
        }

        public StoredStudy Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StoredStudy updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
