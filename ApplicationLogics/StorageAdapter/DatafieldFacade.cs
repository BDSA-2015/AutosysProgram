using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class DatafieldAdapter : IAdapter<DataField>
    {
        public int Create(DataField item)
        {
            throw new NotImplementedException();
        }

        public DataField Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DataField> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(DataField item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DataField item)
        {
            throw new NotImplementedException();
        }
    }

}
