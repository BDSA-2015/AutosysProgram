using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    /// <summary>
    /// This class is responsible for the communication between application logic layer and storage layer.
    /// This class will handle Teams and convert them the the propriate object that are to be propagated
    /// </summary>
    public class TeamAdapter : IAdapter<Team>
    {
        private readonly IRepository<StoredTeam> _teamRepository;

        public TeamAdapter(IRepository<StoredTeam> repository)
        {
            _teamRepository = repository;
        }

        /// <summary>
        /// Creates a new team in database
        /// </summary>
        /// <param name="team"> Team object</param>
        /// <returns>Id of team</returns>
        public int Create(Team team)
        {
            return _teamRepository.Create(Mapper.Map<StoredTeam>(team));
        }

        /// <summary>
        /// Deletes a team from database
        /// </summary>
        /// <param name="team">team object</param>
        public void Delete(Team team)
        {
            var toDelete = Read(team.Id);
            if (toDelete == null) throw new NullReferenceException("Team does not exist");

            if ((team.Id == toDelete.Id) && (team.MetaData == toDelete.MetaData) && (team.Name == toDelete.Name) &&
                team.UserIDs.Equals(toDelete.UserIDs))
        {
                var storedteamToDelete = Mapper.Map<StoredTeam>(toDelete);
                _teamRepository.DeleteIfExists(storedteamToDelete);
            }
            else throw new ArgumentException("Team has been updated");

        }

        /// <summary>
        /// Read all teams in database
        /// </summary>
        /// <returns>Enumerable collection of all teams</returns>
        public IEnumerable<Team> Read()
        {
            var storedTeam = _teamRepository.Read();

            var teams = Enumerable.ToList(storedTeam.Select(Mapper.Map<Team>));
                //Converts storedUsers to user and return as a list
            return teams;
        }

        /// <summary>
        /// Reads a given team from a specific id
        /// </summary>
        /// <param name="id">id of team</param>
        /// <returns>team object</returns>
        public Team Read(int id)
        {
            var storedTeam = _teamRepository.Read(id);
            return Mapper.Map<Team>(storedTeam);
        }

        /// <summary>
        /// Updates an existing team in database
        /// </summary>
        /// <param name="team">team object</param>
        public void Update(Team team)
        {
            _teamRepository.UpdateIfExists(Mapper.Map<StoredTeam>(team));
        }
    }
}
