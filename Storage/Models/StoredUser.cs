using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     A user can be part of a team working on a given study and if so can be assigned different roles defining task
    ///     possibilities.
    /// </summary>
    public class StoredUser : IEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string MetaData { get; set; }

        [Key]
        public int Id { get; set; }

        public int StoredTeamId { get; set; }

        public virtual StoredTeam Team { get; set; }
    }
}