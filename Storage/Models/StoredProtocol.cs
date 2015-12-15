using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents the entity used to store Protocols outlining how a study is configured.
    /// </summary>
    [Table("Protocol")]
    public class StoredProtocol : IEntity
    {

        public virtual ICollection<StoredCriteria> InclusionCriteria { get; set; } 

        public virtual ICollection<StoredCriteria> ExclusionCriteria { get; set; }

        public virtual ICollection<StoredPhase> StudyPhases { get; set; }

        [Required]
        [StringLength(50)]
        public string StudyName { get; set; }

        [Required]
        [StringLength(400)]
        public string StudyDescription { get; set; }

        [Key]
        public int Id { get; set; }
    }
}