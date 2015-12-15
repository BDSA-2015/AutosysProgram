using AutoMapper;
using WebApi.Models;

namespace WebApi.Mapping.Profiles
{
    /// <summary>
    ///     This class is an Automapper profile that
    ///     specifies how the mappings are for the UserManagement Subsystem.
    ///     It will basically map DTO, Application logic objects and storage entites
    ///     together so they can be converted by AutoMapper
    ///     https://github.com/AutoMapper/AutoMapper/wiki/Configuration
    ///     http://stackoverflow.com/questions/6825244/where-to-place-automapper-createmaps
    /// </summary>
    public class UserAndTeamDtoProfile : Profile
    {
        /// <summary>
        ///     Maps source to a destination object
        /// </summary>
        /// <returns>destination object</returns>
        protected override void Configure()
        {
            CreateUserMappings();
            CreateTeamMappings();
        }

        private void CreateUserMappings()
        {
            //DTO to User
            Mapper.CreateMap<User, ApplicationLogics.UserManagement.Entities.User>();

            //User to DTO
            Mapper.CreateMap<ApplicationLogics.UserManagement.Entities.User, User>();
        }

        private void CreateTeamMappings()
        {
            //DTO to User
            Mapper.CreateMap<Team, ApplicationLogics.UserManagement.Entities.Team>();

            //User to DTO
            Mapper.CreateMap<ApplicationLogics.UserManagement.Entities.Team, Team>();
        }
    }
}