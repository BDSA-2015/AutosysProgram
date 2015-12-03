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
    /// This class represents a team of users created prior to a given study.
    /// The team can be assigned to a given study and different teams are assumed one if assigned to the the same study. 
    /// </summary>
    [Table("Team")]
    public class StoredTeam : IEntity
    {

        [Key]
        public int Id { get; set; }

        [Required][StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int[] UserIDs { get; set; }

        [StringLength(400)]
        public string Metadata { get; set; }

    }

}
