using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class PhaseAdapter : IAdapter<Phase>
    {
        public int Create(Phase item)
        {
            throw new NotImplementedException();
        }

        public Phase Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phase> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Phase item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Phase item)
        {
            throw new NotImplementedException();
        }
    }

}
