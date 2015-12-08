using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{
    public class StudyRepository : IRepository<StoredStudy>
    {
        public int CreateOrUpdate(StoredStudy item)
        {
            throw new NotImplementedException();
        }

        public void DeleteIfExists(StoredStudy item)
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

        public void UpdateIfExists(StoredStudy item)
        {
            throw new NotImplementedException();
        }
    }
}
