// Task.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     This class represents an assignment in a given phase in a study.
    ///     A task is deﬁned by a unique id, a set of visible data ﬁelds (unmodiﬁable), a set of requested data ﬁelds
    ///     (modiﬁable) and a type.
    ///     A taks type can either be request to ﬁll out data ﬁeld(s) or a request to handle conﬂicting data ﬁeld(s).
    ///     By way of example, a phase could involve review tasks assigned for two reviewers.
    ///     A validator could then analyze any inconsistencies between the work of both reviewers in a second phase .
    /// </summary>
    public class TaskRequest
    {
        public int Id { get; set; }

        /// <summary>
        ///     Defines if a Task is completed or is still in progress
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        ///     The Id of the specified User associated with this Task
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     The Task description, which defines the work to be completed in the Task
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     A collection of non modifiable fields containing to be visualized to a Client.
        ///     A field can be a tag imported from a file e.g. the entry from a bibtex file or the field type and its value
        /// </summary>
        private List<string> VisibleDataFields { get; set; }

        /// <summary>
        ///     A collection of modifiable fields which are defined by a Client
        /// </summary>
        public List<DataField> RequestedDataFields { get; set; }
    }
}