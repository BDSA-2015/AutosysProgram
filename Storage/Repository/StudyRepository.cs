using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;
using Storage.Entities;

namespace Storage.Repository
{
    public class StudyRepository : IRepository<StoredStudy>
    {
        public int Create(StoredStudy item)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredStudy item)
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

        public void Update(StoredStudy item)
        {
            throw new NotImplementedException();
        }
    }
}
