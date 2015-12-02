using ApplicationLogics.StorageFasade.Mapper;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using Storage.Entities;

namespace ApplicationLogics.StorageFasade.Mapping
{
    /// <summary>
    /// This class is used to convert user objects in the logical layer (UserDto, User)
    /// to user objects in the storage layer (StoredUser), vice versa. 
    /// To see different mappings, look at BaseMapperStub.cs in the test files or
    /// https://github.com/AutoMapper/AutoMapper/wiki/Getting-started
    /// </summary>
    public class BaseMapper : IMap
    {
      
       /// <summary>
       /// Maps source to a destination object
       /// </summary>
       /// <param name="source"> source object</param>
       /// <param name="destination"> destination object</param>
       /// <returns>destination object</returns>
        public void CreateMappings()
        {
            CreateUserMappings();
            CreateTeamMappings();
        }

        /// <summary>
        /// Creates mappings for User in application logic, DTO and StoredEntity
        /// </summary>
        private void CreateUserMappings()
        {
            //DTO to User
            AutoMapper.Mapper.CreateMap<SystematicStudyService.Models.User, User>();
            
            //User to DTO
            AutoMapper.Mapper.CreateMap<User, SystematicStudyService.Models.User>();

            //User to StoredEntity
            AutoMapper.Mapper.CreateMap<User, StoredUser>();

            //StoredEntity to User
            AutoMapper.Mapper.CreateMap<StoredUser,User>();

        }

        /// <summary>
        /// Creates mappings for Team in application logic, DTO and StoredEntity
        /// </summary>
        private void CreateTeamMappings()
        {
            //DTO to Team
            AutoMapper.Mapper.CreateMap<SystematicStudyService.Models.Team, Team>();

            //Team to DTO
            AutoMapper.Mapper.CreateMap<Team, SystematicStudyService.Models.Team>();


            //Team to StoredEntity
            AutoMapper.Mapper.CreateMap<Team, StoredTeam>();

            //StoredEntity to User
            AutoMapper.Mapper.CreateMap<StoredTeam, Team>();
        }
    }
}
