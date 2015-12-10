// UserManagementStorageProfile.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using AutoMapper;
using Storage.Models;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles
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
            CreateTeamMappings();
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
            //StoredTeam to Team
            Mapper.CreateMap<StoredTeam, Team>()
                .ForMember(target => target.UserIDs,
                            opt => opt.MapFrom(storedTeam => storedTeam.UserIds));


            //Team to StoredTeam
            Mapper.CreateMap<Team, StoredTeam>()
                .ForMember(user => user.UserIds,
                            opt => opt.MapFrom(storedUser => storedUser.UserIDs));
        }
    }
}