using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents the entity used to store a task, an assignment in a given phase in a study.
    ///     A task is deﬁned by a unique id, a set of visible data ﬁelds (unmodiﬁable), a set of requested data ﬁelds
    ///     (modiﬁable) and a type.
    ///     A taks type can either be request to ﬁll out data ﬁeld(s) or a request to handle conﬂicting data ﬁeld(s).
    ///     By way of example, a phase could involve review tasks assigned for two reviewers.
    ///     A validator could then analyze any inconsistencies between the work of both reviewers in a second phase.
    /// </summary>
    [Table("Task")]
    public class StoredTaskRequest : IEntity
    {

        #region Properties 

        public TypeOptions Type { get; set; }

        public ProgressOptions Progress { get; set; }

        /// <summary>
        ///     Determines task state
        /// </summary>
        public bool IsFinished { get; set; }

        /// <summary>
        ///     The task description to be followed for completing the task
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Referenced entities

        /// <summary>
        ///     Visible fields (unmodifiable) presented to a reviewer doing the task (e.g. author and the name of the author)
        /// </summary>
        public virtual ICollection<StoredDataField> VisibleDataFields { get; set; }

        /// <summary>
        ///     Modifiable fields, which a reviewer needs to fill out for a specific paper
        /// </summary>
        public virtual ICollection<StoredDataField> RequestedDataFields { get; set; }

        /// <summary>
        ///     In case this is a <see cref="TypeOptions.HandleConflictingDatafields" /> task, represents for each of the <see cref="RequestedDataFields" /> the
        ///     list of <see cref="ConflictingData" /> provided by separate users.
        ///     Each StoredFieldConflict represents a data field entry with a list of conflicts. 
        /// </summary>
        public virtual ICollection<StoredFieldConflicts> ConflictingData { get; set; }

        #endregion

        #region Keys 

        [Key]
        public int Id { get; set; }

        public virtual PhaseTask PhaseTask { get; set; }

        #endregion

        #region Enum Helpers 

        /// <summary>
        ///     Determines the status of a given task
        /// </summary>
        public enum ProgressOptions
        {
            NotStarted,
            Started,
            Done
        }

        /// <summary>
        ///     Determines the type of Task
        ///     FillOutDataFields for Reviewer
        ///     HandleConflictingDatafields for Validator
        /// </summary>
        public enum TypeOptions
        {
            FillOutDataFields,
            HandleConflictingDatafields
        }

        /// <summary>
        ///     Used to map the enum Type as a string.
        /// </summary>
        [Column("Type")]
        public string TypeString
        {
            get { return Type.ToString(); }
            private set { Type = EnumExtensions.ParseEnum<TypeOptions>(value); }
        }

        /// <summary>
        ///     Used to map the enum Progress as a string.
        /// </summary>
        [Column("Progress")]
        public string ProgressString
        {
            get { return Progress.ToString(); }
            private set { Progress = EnumExtensions.ParseEnum<ProgressOptions>(value); }
        }

        #endregion

    }

}