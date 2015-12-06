// TeamValidator.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageFasade.Interface;

namespace ApplicationLogics.UserManagement.Utils
{
    /// <summary>
    /// Responsible for validating teams
    /// </summary>
    public class TeamValidator
    {
        /// <summary>
        /// Validate existience of team
        /// </summary>
        /// <param name="teamId">team to find</param>
        /// <param name="teamFasade">Storage location</param>
        /// <returns>Existence of team</returns>
        public static bool ValidateExistence(int teamId, IFacade<Team> teamFasade)
        {
            if (teamId < 0) return false;
            var team = teamFasade.Read(teamId);
            return team != null;
        }

        /// <summary>
        /// Validation of team information
        /// </summary>
        /// <param name="team">team to validate</param>
        /// <returns>validated team information</returns>
        public static bool ValidateEnteredTeamData(Team team)
        {
            return
                team.Id>=0 &&
                !string.IsNullOrWhiteSpace(team.Name) &&
                !string.IsNullOrWhiteSpace(team.MetaData) &&
                (team.UserIDs.Length > 0);
        }

        internal static bool ValidateId(int id)
        {
            return id >= 0;
        }
    }
}