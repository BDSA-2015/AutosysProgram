using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationLogics.Repository;
using Storage.Entities;

namespace Storage.Models
{
    
    /// <summary>
    /// This class represents a Criteria entity used to synthesize data in a given study. 
    /// </summary>
    [Table("Criteria")]
    public class StoredCriteria : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [NotMapped] // Not mapped in database but created dynamically 
        public virtual StoredDataField DataField { get; set; }
    }

}
