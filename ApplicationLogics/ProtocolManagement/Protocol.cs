// Protocol.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ProtocolManagement
{
    /// <summary>
    ///     This class represents the Research Protocol created from the configuration details of a specific study.
    ///     A protocol can be exported to a client in a specified format e.g. a protocol can be formatted to CSV and exported
    /// </summary>
    public class Protocol
    {
        public string StudyName { get; set; }
        public List<Phase> StudyPhases { get; set; }
        public string StudyDescription { get; set; }

        public List<Criteria> InclusionCriteria { get; set; } // UpdateIfExists Csv tests and remove this  

        public List<Criteria> ExclusionCriteria { get; set; } // UpdateIfExists Csv tests and remove this  
    }
}