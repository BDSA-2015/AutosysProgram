using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace Storage.Entities
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
