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
        [Required]
        [StringLength(50)]
        public string StudyName { get; set; }

        [Required]
        public virtual ICollection<StoredPhase> Phases { get; set; }

        [Required]
        [StringLength(400)]
        public string Description { get; set; }

        [Key]
        public int Id { get; set; }
    }
}