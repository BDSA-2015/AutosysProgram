using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store teams in the database. 
    /// </summary>
    public class TeamRepository : IRepository<StoredTeam>
    {
        public Task<int> Create(StoredTeam user)
        {
            throw new NotImplementedException();
        }

        public Task<StoredTeam> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(StoredTeam user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(StoredTeam user)
        {
            throw new NotImplementedException();
        }
    }

}
