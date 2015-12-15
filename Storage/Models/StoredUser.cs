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

        #region User properties 
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string MetaData { get; set; }

        #endregion

        #region Keys

        [Key]
        public int Id { get; set; }

        public virtual StoredTeam Team { get; set; }

        public virtual StoredStudy Study { get; set; }

        public virtual PhaseRole PhaseRole { get; set; }

        #endregion

    }

}