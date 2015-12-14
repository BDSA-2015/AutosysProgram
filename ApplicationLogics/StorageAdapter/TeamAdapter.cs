using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using AutoMapper;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    /// <summary>
    ///     This class is responsible for the communication between application logic layer and storage layer.
    ///     This class will handle Teams and convert them the the propriate object that are to be propagated
    /// </summary>
    public class TeamAdapter : IAdapter<Team>
    {
        private readonly IRepository<StoredTeam> _teamRepository;

        public TeamAdapter(IRepository<StoredTeam> repository)
        {
            _teamRepository = repository;
        }

        /// <summary>
        ///     Reads storedteam and returns a team to the caller.
        /// </summary>
        /// <param name="id"> Id in database</param>
        /// <returns>Team</returns>
        public async Task<Team> Read(int id)
        {
            return Mapper.Map<Team>(await _teamRepository.Read(id));
        }

        /// <summary>
        ///     Returns an IQueryable set of teams
        /// </summary>
        /// <returns>IQueryable set of teams</returns>
        public IQueryable<Team> Read()
        {
            var storedTeam =  _teamRepository.Read();
            return storedTeam.Select(Mapper.Map<Team>).AsQueryable();
        }

        /// <summary>
        ///     Converts team to storage entity and update it.
        /// </summary>
        /// <param name="team">Team object</param>
        public async Task<bool> UpdateIfExists(Team team)
        {
            return await _teamRepository.UpdateIfExists(Mapper.Map<StoredTeam>(team));
        }

        /// <summary>
        ///     DeleteIfExists given team from database.
        /// </summary>
        /// <param name="id">id of team</param>
        public async Task<bool> DeleteIfExists(int id)
        {
            var result = await _teamRepository.DeleteIfExists(id);
            if (!result) throw new NullReferenceException(nameof(id));
            return true;
        }

        /// <summary>
        ///     Creates a new storedTeam from team details and send it to repository
        /// </summary>
        /// <param name="team">team</param>
        /// <returns> int</returns>
        public async Task<int> Create(Team team)
        {
            return await _teamRepository.Create(Mapper.Map<StoredTeam>(team));
        }


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