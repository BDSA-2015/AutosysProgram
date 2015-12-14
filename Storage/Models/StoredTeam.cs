using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents a team of users created prior to a given study.
    ///     The team can be assigned to a given study and different teams are assumed one if assigned to the the same study.
    /// </summary>
    [Table("Team")]
    public class StoredTeam : IEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int[] UserIds { get; set;}

        [StringLength(400)]
        public string MetaData { get; set; }

        [Key]
        public int Id { get; set; }
    }
}