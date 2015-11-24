// Study.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Study : IEntity
    {
        /// <summary>
        ///     The Study's name. Try to keep the name unique
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     What kind of study  is this
        /// </summary>
        public string Classification { get; set; }

        /// <summary>
        ///     A quick summary of the study
        /// </summary>
        public string description { get; set; }

        /// <summary>
        ///     The phases the project has been through and the current phase
        /// </summary>
        public List<Phase> phases { get; set; }

        public int Id { get; set; }
    }
}