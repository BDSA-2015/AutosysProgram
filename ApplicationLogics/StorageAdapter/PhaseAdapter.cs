using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class PhaseAdapter : IAdapter<Phase>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(Phase user)
        {
            throw new NotImplementedException();
        }

        public Task<Phase> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Phase> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(Phase user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public Phase Map(Phase item)
        {
            throw new NotImplementedException();
        }
    }

}