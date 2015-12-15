// Task.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     This class represents an assignment in a given phase in a study.
    ///     By way of example, a phase could involve review tasks assigned to two reviewers.
    ///     A validator could then analyze any inconsistencies between the work of both reviewers in a second phase by looking at ConflictingData.
    /// </summary>
    public class TaskRequest
    {
        public int Id { get; set; }

        public Type TaskType { get; set; }

        /// <summary>
        ///     The possible types of a task
        /// </summary>
        public enum Type
        {
            Review,
            Conflict,
            Both
        } 

        /// <summary>
        ///     Determines task state
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        ///     The id of the paper which the task is associated with.
        /// </summary>
        public int PaperId { get; set; }

        /// <summary>
        ///     The task description to be followed for completing the task
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Visible fields presented to a reviewer doing the task (e.g. author and the name of the author)
        /// </summary>
        private List<DataField> VisibleDataFields { get; set; }

        /// <summary>
        ///     Modifiable fields, which a reviewer needs to fill out for a specific paper
        /// </summary>
        public List<DataField> RequestedDataFields { get; set; }

        /// <summary>
        ///     In case this is a <see cref="Type.HandleConflictingDatafields" /> task, represents for each of the <see cref="RequestedDataFields" /> the
        ///     list of <see cref="ConflictingData" /> provided by separate users.
        /// </summary>
        public Conflict[][] ConflictingData { get; set; }
    }
}