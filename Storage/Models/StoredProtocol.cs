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
    /// This class represents the entity used to store Protocols outlining how a study is configured. 
    /// </summary>
    [Table("Protocol")]
    public class StoredProtocol : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required][StringLength(400)]
        public string Description { get; set; }

        public virtual List<StoredCriteria> InclusionCriteria { get; set; }

        public virtual List<StoredCriteria> ExclusionCriteria { get; set; }

    }

}
