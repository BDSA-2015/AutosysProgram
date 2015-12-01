// DtoConverter.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.UserManagement.Entities;

namespace ApplicationLogics.UserManagement.Utils
{
    /// <summary>
    /// Responsible for converting user and team Dto's
    /// </summary>
    internal class DtoConverter
    {
        /// <summary>
        /// Converts Dto item to team item.
        /// </summary>
        /// <param name="teamDto">Team Dto</param>
        /// <returns>Team</returns>
        internal static Team ConvertDtoTeam(SystematicStudyService.Models.Team teamDto)
        {
            return new Team
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
            return new User
            {
                Name = userDto.Name.Trim(),
                Metadata = userDto.Metadata.Trim(),
                Id = userDto.Id
            };
        }
    }
}