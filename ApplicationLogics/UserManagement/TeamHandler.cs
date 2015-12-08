// TeamHandler.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement.Utils;

namespace ApplicationLogics.UserManagement
{
    /// <summary>
    /// Responsible for Team operations
    /// </summary>
    public class TeamHandler
    {
        private readonly IFacade<Team> _storage;

        public TeamHandler(IFacade<Team> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Validates if a team exists in database.
        /// </summary>
        /// <param name="id">team Id</param>
        /// <returns>bool of team existence</returns>
        public bool ValidateTeam(int id)
        {
            return TeamValidator.ValidateExistence(id, _storage);
        }

        /// <summary>
        /// Creates a new team
        /// </summary>
        /// <param name="team"> Team Object</param>
        public int Create(Team team)
        {
            if (!TeamValidator.ValidateEnteredTeamData(team))
                throw new ArgumentException("Team data is invalid");

           return _storage.Create(team);
        }

        /// <summary>
        /// DeleteIfExists a team from database
        /// </summary>
        /// <param name="id">id of team</param>
        public void Delete(int id)
        {
            if (!TeamValidator.ValidateExistence(id, _storage))
                throw new ArgumentException("Team does not exist");

            var team = _storage.Read(id);
            _storage.Delete(team);
        }

        /// <summary>
        ///     Updates existing team with new team informations
        /// </summary>
        /// <param name="oldId"> id of existing team</param>
        /// <param name="team"> Team object</param>
        public void Update(int oldId, Team team)
        {
            if (!TeamValidator.ValidateEnteredTeamData(team)) throw new ArgumentException("Team data is invalid");
            if (!TeamValidator.ValidateExistence(oldId, _storage)) throw new ArgumentException("Team does not exist");
            _storage.Update(team);
        }

        /// <summary>
        /// Returns every teams stored in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Team> GetAll()
        {
            return _storage.Read();
        }

        /// <summary>
        /// Returns every teams stored in database
        /// </summary>
        /// <returns></returns>
        public Team Read(int id)
        {
            if(!TeamValidator.ValidateId(id))
                throw new ArgumentException("Id is not valid");
            return _storage.Read(id);
        }
    }
}