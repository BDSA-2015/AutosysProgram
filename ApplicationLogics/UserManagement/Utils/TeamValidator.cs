using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StorageFasade;

namespace ApplicationLogics.UserManagement.Utils
{
    /// <summary>
    /// Responsible for validating teams
    /// </summary>
    class TeamValidator
    {
        /// <summary>
        /// Validate existience of team
        /// </summary>
        /// <param name="teamId">team to find</param>
        /// <param name="teamFasade">Storage location</param>
        /// <returns>Existence of team</returns>
        internal static bool ValidateExistence(int teamId, IFasade<Team> teamFasade)
        {
            var team = teamFasade.Read(teamId);
            return team != null;
        }

        /// <summary>
        /// Validation of team information
        /// </summary>
        /// <param name="team">team to validate</param>
        /// <returns>validated team information</returns>
        internal static bool ValidateEnteredTeamData(Team team)
        {
            return 
                !string.IsNullOrEmpty(team.Name) && 
                !string.IsNullOrEmpty(team.Metadata) && 
                (team.UserIDs.Length > 0);
        }
    }
}
