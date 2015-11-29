using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement.Utils;
using Microsoft.SqlServer.Server;

namespace ApplicationLogics.UserManagement
{
    class TeamHandler
    {
        private readonly IFasade<Team> _storage; 

        public TeamHandler(IFasade<Team> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Validates if a team exists in database.
        /// </summary>
        /// <param name="id">team Id</param>
        /// <returns>bool</returns>
        public bool ValidateTeam(int id)
        {
            return TeamValidator.ValidateExistence(id, _storage);
        }

        /// <summary>
        /// Creates a new team
        /// </summary>
        /// <param name="teamDto"> dto Item from webAPI</param>
        public void Create(SystematicStudyService.Models.Team teamDto)
        {

            var team = DtoConverter.ConvertDtoTeam(teamDto);
            if(!TeamValidator.ValidateEnteredTeamData(team))
                throw new ArgumentException("Team data is invalid");

            _storage.Create(team);
        }

        /// <summary>
        /// Delete a team from database
        /// </summary>
        /// <param name="id">id of team</param>
        public void Delete(int id)
        {
            if (!TeamValidator.ValidateExistence(id, _storage))
                throw new ArgumentException("Team does not exist");

            var team = _storage.Read(id);
            _storage.Delete(team);
        }

        public void Update(int oldId, SystematicStudyService.Models.Team teamDto)
        {
            var team = DtoConverter.ConvertDtoTeam(teamDto);
            if (!TeamValidator.ValidateEnteredTeamData(team))       throw new ArgumentException("Team data is invalid");
            if (!TeamValidator.ValidateExistence(oldId,_storage))   throw new ArgumentException("Team does not exist");

            _storage.Update(team);


        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _storage.Read();
        } 

     
    }
}
