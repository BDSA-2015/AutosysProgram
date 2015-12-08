using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Entities
{

    /// <summary>
    /// This class represents the Phase entity detailing how task requests are handled and handed out. 
    /// Each phase is dependent on each other sequentially and is completed in a ﬁxed order. 
    /// </summary>
    [Table("Phase")]
    public class StoredPhase : IEntity
    {
        [Key]
        public int Id { get; set; }

        public virtual StoredStudy Study { get; set; }

        public virtual ICollection<StoredPaper> Reports { get; set; }

        public ICollection<StoredCriteria> ExclusionCriteria { get; set; }

        /// <summary>
        /// This list contains Criteria, which each report must contain.
        /// </summary>
        public ICollection<StoredCriteria> InclusionCriteria { get; set; }

        public string IsFinished { get; set; } 

        public virtual ICollection<StoredCriteria> Criteria { get; set; }

        public virtual IDictionary<StoredTaskRequest, List<StoredUser>> AssignedTask { get; set; }

        public virtual IDictionary<StoredUser, StoredRole> AssignedRole { get; set; }

        public virtual ICollection<StoredTaskRequest> UnassignedTasks { get; set; }

        public virtual ICollection<StoredPhase> DependentPhases { get; set; }

    }

}
