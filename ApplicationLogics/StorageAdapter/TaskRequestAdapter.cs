using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class TaskRequestAdapter : IAdapter<TaskRequest>
    {
        public int Create(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public TaskRequest Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRequest> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public TaskRequest Map(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}