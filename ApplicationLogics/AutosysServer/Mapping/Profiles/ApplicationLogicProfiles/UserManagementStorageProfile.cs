// UserManagementStorageProfile.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.UserManagement;
using AutoMapper;
using Storage.Entities;
using Storage.Models;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles.ApplicationLogicProfiles
{
    /// <summary>
    /// This profile sets the mapping between
    /// Applicationlogic objects and Stored Entities for Usermanagement subsystem
    /// </summary>
    internal class UserManagementStorageProfile : Profile
    {
        protected override void Configure()
        {
            CreateUserMappings();
            CreateUserMappings();
        }


        /// <summary>
        /// Creates mappings between user and storedUser
        /// </summary>
        private void CreateUserMappings()
        {
            //StoredUser to User
            Mapper.CreateMap<StoredUser,User>();

            //User to StoredUser
            Mapper.CreateMap<User, StoredUser>();
        }

        /// <summary>
        /// Creates mappings between team and storedTeam
        /// </summary>
        private void CreateTeamMappings()
        {
            //StoredUser to User
            Mapper.CreateMap<StoredTeam, Team>();

            //User to StoredUser
            Mapper.CreateMap<Team, StoredTeam>();
        }
    }
}