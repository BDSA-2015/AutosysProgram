using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{
    public class TeamRepository : IRepository<StoredTeam>
    {
        public int Create(StoredTeam item)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredTeam item)
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

        public void Update(StoredTeam item)
        {
            throw new NotImplementedException();
        }
    }
}
