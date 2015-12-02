using ApplicationLogics.StorageFasade.Mapper;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.StorageFasade.Mapping
{
    /// <summary>
    /// This class is used to convert user objects in the logical layer (UserDto, User)
    /// to user objects in the storage layer (StoredUser), vice versa. 
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
