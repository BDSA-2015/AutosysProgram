// Study.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{
    public class Study 
    {
        public string Name { get; set; }

        /// <summary>
        /// Study type. 
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        /// A quick summary of the study
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Phases that study has undergone and the current phase.
        /// </summary>
        public List<Phase> Phases { get; set; }

    }

}