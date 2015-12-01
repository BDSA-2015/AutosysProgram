// Task.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{

    /// <summary>
    /// This class represents an assignment in a given phase in a study. 
    /// A task is deﬁned by a unique id, a set of visible data ﬁelds (unmodiﬁable), a set of requested data ﬁelds (modiﬁable) and a type. 
    /// A taks type can either be request to ﬁll out data ﬁeld(s) or a request to handle conﬂicting data ﬁeld(s). 
    /// By way of example, a phase could involve review tasks assigned for two reviewers. 
    /// A validator could then analyze any inconsistencies between the work of both reviewers in a second phase. 
    /// </summary>
    public class TaskRequest 
    {
        /// <summary>
        /// Determines task states; initialized, in progress or completed
        /// </summary>
        public enum Progress
        {
            NotStarted,
            Started,
            Done
        }

        public enum Type
        {
            FillOutDataFields,
            HandleConflictingDatafields
        }

        public string Description { get; set; }

        private List<DataField> NonModifiableDatafields { get; set; }

        public List<DataField> ModifiableDatafields { get; set; }
    }

}