using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store teams in the database. 
    /// </summary>
    public class TeamRepository : IRepository<StoredTeam>
    {
        public int Create(StoredTeam user)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredTeam user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoredTeam> Read()
        {
            throw new NotImplementedException();
        }

        public StoredTeam Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StoredTeam updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
