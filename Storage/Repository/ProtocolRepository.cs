using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class ProtocolRepository : DbRepository<StoredProtocol>
    {
    }

}
