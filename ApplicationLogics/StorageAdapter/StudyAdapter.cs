using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class StudyAdapter : IAdapter<Study>
    {
        public int Create(Study item)
        {
            throw new NotImplementedException();
        }

        public Study Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Study> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Study item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Study item)
        {
            throw new NotImplementedException();
        }

        public Study Map(Study item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}