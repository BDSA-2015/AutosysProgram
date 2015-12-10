using System;
using System.Collections.Generic;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StorageAdapter.Interface;

namespace ApplicationLogics.StorageAdapter
{
    public class ProtocolAdapter : IAdapter<Protocol>
    {
        public int Create(Protocol item)
        {
            throw new NotImplementedException();
        }

        public Protocol Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Protocol> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(Protocol item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Protocol item)
        {
            throw new NotImplementedException();
        }
    }

}
