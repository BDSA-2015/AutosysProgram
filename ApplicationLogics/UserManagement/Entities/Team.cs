// Team.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.UserManagement
{
    /// <summary>
    /// This class represents a team of users created prior to a given study.
    /// The team can be assigned to a given study and different teams are assumed one if assigned to the the same study.
    /// </summary>
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] UserIDs { get; set; }
        public string MetaData { get; set; }

    }
}