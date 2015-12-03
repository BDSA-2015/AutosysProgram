using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using AutoMapper;

namespace ApplicationLogics.AutosysServer.Mapping.Profiles.WebApiProfile
{
    /// <summary>
    /// This class is an Automapper profile that
    /// specifies how the mappings are for the UserManagement Subsystem.
    /// It will basically map DTO, Application logic objects and storage entites 
    /// together so they can be converted by AutoMapper
    /// https://github.com/AutoMapper/AutoMapper/wiki/Configuration
    /// http://stackoverflow.com/questions/6825244/where-to-place-automapper-createmaps
    /// </summary>
    public class UserAndTeamDTOProfile : Profile
    {

        /// <summary>
        /// Maps source to a destination object
        /// </summary>
        /// <param name="source"> source object</param>
        /// <param name="destination"> destination object</param>
        /// <returns>destination object</returns>
        protected override void Configure()
        {
            CreateUserMappings();
            CreateTeamMappings();
        }

        private void CreateUserMappings()
        {
            //DTO to User
            AutoMapper.Mapper.CreateMap<SystematicStudyService.Models.User, User>();
            
            //User to DTO
            AutoMapper.Mapper.CreateMap<User, SystematicStudyService.Models.User>();
        }

        private void CreateTeamMappings()
        {
            //DTO to User
            AutoMapper.Mapper.CreateMap<SystematicStudyService.Models.Team, Team>();

            //User to DTO
            AutoMapper.Mapper.CreateMap<Team, SystematicStudyService.Models.Team>();
        }
    }
}
