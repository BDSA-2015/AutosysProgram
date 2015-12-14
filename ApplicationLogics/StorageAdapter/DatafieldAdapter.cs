using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class DatafieldAdapter : IAdapter<DataField>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(DataField user)
        {
            throw new NotImplementedException();
        }

        public Task<DataField> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DataField> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(DataField user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public DataField Map(DataField item)
        {
            throw new NotImplementedException();
        }
    }

}