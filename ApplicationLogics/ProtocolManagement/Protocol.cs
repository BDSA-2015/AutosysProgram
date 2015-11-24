// Protocol.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using ApplicationLogics.Repository;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ProtocolManagement
{
    /// <summary>
    /// This class represents the Research Protocol used to configure a given study.
    /// </summary>
    public class Protocol : IEntity
    {
        public int Id { get; set; }

        public List<Criteria> InclusionCriteria { get; set; }

        public List<Criteria> ExclusionCriteria { get; set; }

        public string Description { get; set; } // Describes protocol goal
    }
}