using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class TaskRequestAdapter : IAdapter<TaskRequest>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(TaskRequest user)
        {
            throw new NotImplementedException();
        }

        public Task<TaskRequest> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaskRequest> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(TaskRequest user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public TaskRequest Map(TaskRequest item)
        {
            throw new NotImplementedException();
        }
    }

}