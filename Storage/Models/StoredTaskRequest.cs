using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace Storage.Entities
{

    /// <summary>
    /// This class represents the entity used to store a task, an assignment in a given phase in a study. 
    /// A task is deﬁned by a unique id, a set of visible data ﬁelds (unmodiﬁable), a set of requested data ﬁelds (modiﬁable) and a type. 
    /// A taks type can either be request to ﬁll out data ﬁeld(s) or a request to handle conﬂicting data ﬁeld(s). 
    /// By way of example, a phase could involve review tasks assigned for two reviewers. 
    /// A validator could then analyze any inconsistencies between the work of both reviewers in a second phase. 
    /// </summary>
    [Table("Task")]
    public class StoredTaskRequest : IEntity
    {

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

        [Key]
        public int Id { get; set; }

        [NotMapped]
        public Type TaskType { get; set; }

        /// <summary>
        /// Used to map the enum Type as a string. 
        /// </summary>
        [Required]
        [Column("Type")]
        public string TypeString
        {
            get { return TaskType.ToString(); }
            private set { TaskType = EnumExtensions.ParseEnum<Type>(value); }
        }

        [NotMapped]
        public Type TaskProgress { get; set; }

        /// <summary>
        /// Used to map the enum Progress as a string. 
        /// </summary>
        [Required]
        [Column("Progress")]
        public string ProgressString
        {
            get { return TaskProgress.ToString(); }
            private set { TaskProgress = EnumExtensions.ParseEnum<Type>(value); } // TODO Shouldnt it ParseEnum<Progress> 
        }

        public string Description { get; set; }

        [Required]
        public virtual List<StoredDataField> NonModifiableDatafields { get; set; }

        [Required]
        public virtual List<StoredDataField> ModifiableDatafields { get; set; }
    }

}
