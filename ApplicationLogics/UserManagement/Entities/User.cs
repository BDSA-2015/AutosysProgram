// User.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.UserManagement
{

    /// <summary>
    /// A user can be part of a team working on a given study and if so can be assigned different roles defining task possibilities. 
    /// </summary>
    public class User 
    {
        public string Name { get; set; }

        public string Metadata { get; set; }
    }
}