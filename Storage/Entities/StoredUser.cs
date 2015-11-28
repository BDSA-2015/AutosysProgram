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
    /// A user can be part of a team working on a given study and if so can be assigned different roles defining task possibilities. 
    /// </summary>
    [Table("User")]
    public class StoredUser : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required][StringLength(50)]
        public string Name { get; set; }

        [Required][StringLength(50)]
        public string MetaData { get; set; }
    }

}
