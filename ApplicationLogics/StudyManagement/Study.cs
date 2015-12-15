// Study.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using ApplicationLogics.PaperManagement;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     This class represents the whole work process from initiating a research to narrowing down relevant research
    ///     evidence.
    ///     A study consists of diﬀerent phases where data is continuously synthesized and approved by users with different
    ///     roles.
    /// </summary>
    public class Study 
    {
        public string Name { get; set; }

        /// <summary>
        ///     A quick summary of the study
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     The papers which are included in the project.
        ///     Papers are imported from a file (e.g. a bibtex file) which loaded into the program by a client
        /// </summary>
        public ICollection<Paper> Papers { get; set; } 

        /// <summary>
        ///     The data fields defined for a study.
        ///     These data fields will be distributed to tasks which will be associated with each paper in the study.
        /// </summary>
        public ICollection<DataField> DataFields { get; set; } 

        /// <summary>
        ///     This list contains Criteria, which each report cannot contain.
        /// </summary>
        public ICollection<Criteria> ExclusionCriteria { get; set; }

        /// <summary>
        ///     This list contains Criteria, which each report must contain.
        /// </summary>
        public ICollection<Criteria> InclusionCriteria { get; set; }

        /// <summary>
        ///     A list of all the users who are working on the study
        /// </summary>
        public ICollection<int> UserId { get; set; } 

        /// <summary>
        ///     Phases that the study has undergone and the current phase.
        /// </summary>
        public ICollection<Phase> Phases { get; set; }
    }
}