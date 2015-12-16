using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents the Phase entity detailing how task requests are handled and handed out.
    ///     Each phase is dependent on each other sequentially and is completed in a ﬁxed order.
    /// </summary>
    [Table("Phase")]
    public class StoredPhase : IEntity
    {
        #region Phase properties 

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string IsFinished { get; set; }

        #endregion

        #region Referenced entities 

        /// <summary>
        ///     The data fields which needs to be filled out for the phase to be completed
        /// </summary>
        public virtual ICollection<StoredDataField> RequestedDataFields { get; set; }

        /// <summary>
        ///     A collection of key value pairs (PhaseRole) used in dictionary from logic over Roles. Each role holds a list of Users with the assigned Role.
        /// </summary>
        public virtual ICollection<PhaseRole> AssignedRoles { get; set; }

        /// <summary>
        ///     Used to give similar tasks to multiple users, e.g. a review task.
        /// </summary>
        public virtual ICollection<PhaseTask> Tasks { get; set; }

        #endregion

        #region Keys

        [Key]
        public int Id { get; set; }

        public virtual StoredStudy Study { get; set; }

        public virtual StoredProtocol Protocol { get; set; }

        #endregion

    }

}
