using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StorageAdapter.Interface;

namespace ApplicationLogics.StorageAdapter
{
    public class ProtocolAdapter : IAdapter<Protocol>
    {
        public Task<int> Create(Protocol user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Protocol Map(Protocol item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Protocol> Read()
        {
            throw new NotImplementedException();
        }

        public Task<Protocol> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(Protocol user)
        {
            throw new NotImplementedException();
        }
    }

}