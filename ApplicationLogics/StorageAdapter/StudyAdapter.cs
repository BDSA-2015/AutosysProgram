using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class StudyAdapter : IAdapter<Study>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(Study user)
        {
            throw new NotImplementedException();
        }

        public Task<Study> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Study> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(Study user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public Study Map(Study item)
        {
            throw new NotImplementedException();
        }
    }


}