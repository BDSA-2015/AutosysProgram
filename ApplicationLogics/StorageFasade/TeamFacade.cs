using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement;
using Storage.Entities;

namespace ApplicationLogics.StorageFasade
{
    public class TeamFacade : IFacade<Team>
    {

        public TeamFasade(IRepository<StoredTeam> repository)
        {
            
        }

        public int Create(Team item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Team item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> Read()
        {
            throw new NotImplementedException();
        }

        public Team Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Team item)
        {
            throw new NotImplementedException();
        }
    }
}
