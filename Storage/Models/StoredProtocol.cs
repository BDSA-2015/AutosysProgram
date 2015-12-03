using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationLogics.Repository;

namespace Storage.Models
{

    /// <summary>
    /// This class represents the entity used to store Protocols outlining how a study is configured. 
    /// </summary>
    [Table("Protocol")]
    public class StoredProtocol : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required][StringLength(400)]
        public string Description { get; set; }

        public virtual ICollection<StoredCriteria> InclusionCriteria { get; set; }

        public virtual ICollection<StoredCriteria> ExclusionCriteria { get; set; }

    }

}
