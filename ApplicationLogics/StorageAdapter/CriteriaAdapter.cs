using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class CriteriaAdapter : IAdapter<Criteria>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(Criteria user)
        {
            throw new NotImplementedException();
        }

        public Task<Criteria> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Criteria> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(Criteria user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public Criteria Map(Criteria item)
        {
            throw new NotImplementedException();
        }
    }

}