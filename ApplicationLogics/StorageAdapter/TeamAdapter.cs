using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement.Entities;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    /// <summary>
    ///     This class is responsible for the communication between application logic layer and storage layer.
    ///     This class will handle Teams and convert them the the appropriate object that are to be propagated.
    /// </summary>
    public class TeamAdapter : IAdapter<Team>
    {
        private readonly IRepository<StoredTeam> _teamRepository;

        public TeamAdapter(IRepository<StoredTeam> repository)
        {
            _teamRepository = repository;
        }

        /// <summary>
        ///     Reads a given team from the Storage layer and returns it as a team to the caller.
        /// </summary>
        /// <param name="id"> Id in database</param>
        /// <returns>Team</returns>
        public async Task<Team> Read(int id)
        {
            var storedTeam = await _teamRepository.Read(id);
            return Mapper.Map<Team>(storedTeam);
        }

        /// <summary>
        ///     Returns all teams.
        /// </summary>
        /// <returns>IQueryable set of teams</returns>
        public IQueryable<Team> Read()
        {
            var storedTeam =  _teamRepository.Read();
            return storedTeam.Select(Mapper.Map<Team>).AsQueryable();
        }

        /// <summary>
        ///     Converts a team to storage entity and updates it if it exists.
        /// </summary>
        /// <param name="team">Team object</param>
        public async Task<bool> UpdateIfExists(Team team)
        {
            var storedTeam = Mapper.Map<StoredTeam>(team);
            return await _teamRepository.UpdateIfExists(storedTeam);
        }

        /// <summary>
        ///     Deletes a given team from the database if it exists. 
        /// </summary>
        /// <param name="id">id of team</param>
        public async Task<bool> DeleteIfExists(int id)
        {
            var result = await _teamRepository.DeleteIfExists(id);
            if (!result) throw new NullReferenceException(nameof(id));
            return true;
        }

        /// <summary>
        ///     Creates a new team in the Storage layer based on team details that are sent to its respective repository.
        /// </summary>
        /// <param name="team">team</param>
        /// <returns> int</returns>
        public async Task<int> Create(Team team)
        {
            var storedTeam = Mapper.Map<StoredTeam>(team);
            return await _teamRepository.Create(storedTeam);
        }

        // TODO consider removing Map method in interface 
        public Team Map(Team item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _teamRepository.Dispose();
        }

    }

}