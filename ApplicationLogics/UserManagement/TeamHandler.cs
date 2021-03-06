﻿// TeamHandler.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement.Entities;
using ApplicationLogics.UserManagement.Utils;
using Storage.Models;

namespace ApplicationLogics.UserManagement
{
    /// <summary>
    ///     Responsible for Team operations
    /// </summary>
    public class TeamHandler
    {
        private readonly IAdapter<Team, StoredTeam> _storage;

        public TeamHandler(IAdapter<Team, StoredTeam> storage)
        {
            _storage = storage;
        }

        /// <summary>
        ///     Validates if a team exists in database.
        /// </summary>
        /// <param name="id">team Id</param>
        /// <returns>bool of team existence</returns>
        public bool ValidateTeam(int id)
        {
            return TeamValidator.ValidateExistence(id, _storage);
        }

        /// <summary>
        ///     Creates a new team
        /// </summary>
        /// <param name="team"> Team Object</param>
        public async Task<int> Create(Team team)
        {
            if (!TeamValidator.ValidateEnteredTeamData(team))
                throw new ArgumentException("Team data is invalid");

            return await _storage.Create(team);
        }

        /// <summary>
        ///     DeleteIfExists a team from database
        /// </summary>
        /// <param name="id">id of team</param>
        public async Task<bool> Delete(int id)
        {
            return await _storage.DeleteIfExists(id);
        }

        /// <summary>
        ///     Updates existing team with new team informations
        /// </summary>
        /// <param name="oldId"> id of existing team</param>
        /// <param name="team"> Team object</param>
        public async Task<bool> Update(int oldId, Team team)
        {
            if (!TeamValidator.ValidateEnteredTeamData(team)) throw new ArgumentException("Team data is invalid");
            if (!TeamValidator.ValidateExistence(oldId, _storage)) throw new ArgumentException("Team does not exist");
            return await _storage.UpdateIfExists(team);
        }

        /// <summary>
        ///     Returns every teams stored in database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Team> GetAll()
        {
            return _storage.Read();
        }

        /// <summary>
        ///     Returns every teams stored in database
        /// </summary>
        /// <returns></returns>
        public async Task<Team> Read(int id)
        {
            if (!TeamValidator.ValidateId(id))
                throw new ArgumentException("Id is not valid");
            return await _storage.Read(id);
        }
    }
}