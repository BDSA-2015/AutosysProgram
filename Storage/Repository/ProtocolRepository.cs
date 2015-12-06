using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store Protocols in the database. 
    /// </summary>
    public class ProtocolRepository : IRepository<StoredProtocol>
    {
        public Task<int> Create(StoredProtocol user)
        {
            throw new NotImplementedException();
        }

        public Task<StoredProtocol> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(StoredProtocol user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(StoredProtocol user)
        {
            throw new NotImplementedException();
        }

    }

}
