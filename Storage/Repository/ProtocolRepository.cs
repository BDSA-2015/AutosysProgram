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
        public int Create(StoredProtocol user)
        {
            throw new NotImplementedException();
        }

        public StoredProtocol Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoredProtocol> Read()
        {
            throw new NotImplementedException();
        }

        public void Update(StoredProtocol updatedUser)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredProtocol user)
        {
            throw new NotImplementedException();
        }
    }
}
