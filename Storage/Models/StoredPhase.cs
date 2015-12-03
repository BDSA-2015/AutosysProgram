using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Entities;
using Storage.Repository;
using Storage.Repository.Interface;

namespace Storage.Models
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

        public bool IsFinished { get; set; } // TODO Boolean in EF and required data annotation

        public virtual List<StoredCriteria> Criteria { get; set; }

        public virtual Dictionary<StoredTaskRequest, List<StoredUser>> AssignedTask { get; set; }

        public virtual Dictionary<StoredUser, StoredRole> AssignedRole { get; set; }

        public virtual List<StoredTaskRequest> UnassignedTasks { get; set; }

        public virtual List<StoredPhase> DependentPhases { get; set; }

    }

}
