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
    /// A validator could then analyze any inconsistencies between the work of both reviewers in a second phase . 
    /// </summary>
    public class TaskRequest 
    {
        /// <summary>
        /// Filters task requests.
        /// </summary>
        public enum Filter
        {
            /// <summary>
            /// Only list remaining tasks.
            /// </summary>
            Remaining,
            /// <summary>
            /// Only list delivered tasks which are still editable.
            /// </summary>
            Editable,
            /// <summary>
            /// Only list tasks which are done, and are no longer editable.
            /// </summary>
            Done
        }
        
        public Filter TaskType { get; set; }

        public int Id { get; set; }


        public enum Type
        {
            Both,
            FillOutDataFields,
            HandleConflictingDatafields,
            
        }


        public string Description { get; set; }

        private List<DataField> NonModifiableDatafields { get; set; }

        public List<DataField> ModifiableDatafields { get; set; }

        /// <summary>
        /// In case this is a <see cref="Type.Conflict" /> task, represents for each of the <see cref="RequestedFields" /> the list of <see cref="ConflictingData" /> provided by separate users.
        /// </summary>
        public ConflictingData[][] ConflictingData { get; set; }
    }

}