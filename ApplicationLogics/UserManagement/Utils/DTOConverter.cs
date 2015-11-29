using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.UserManagement.Utils
{
    /// <summary>
    /// Responsible for converting user and team Dto's
    /// </summary>
    class DtoConverter
    {
        /// <summary>
        /// Converts Dto item to team item.
        /// </summary>
        /// <param name="teamDto">Team Dto</param>
        /// <returns>Team</returns>
        internal static Team ConvertDtoTeam(SystematicStudyService.Models.Team teamDto)
        {
            return new Team()
            {
                Name = teamDto.Name.Trim(),
                Metadata = teamDto.Metadata.Trim(),
                UserIDs = teamDto.UserIDs
            };
        }

        /// <summary>
        /// Convert a UserDto to a user
        /// </summary>
        /// <param name="userDto">UserDto</param>
        /// <returns>User</returns>
        internal static User ConvertDtoUser(SystematicStudyService.Models.User userDto)
        {
            return new User()
            {
                Name = userDto.Name.Trim(),
                Metadata = userDto.Metadata.Trim()
            };
        }
    }
}
