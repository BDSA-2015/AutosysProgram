// Role.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     A role is assigned to a user in a given phase and determines what tasks are to be received.
    /// </summary>
    public class Role
    {
        public enum Type
        {
            Validator,
            Reviewer
        }

        public Type RoleType { get; set; }
    }
}