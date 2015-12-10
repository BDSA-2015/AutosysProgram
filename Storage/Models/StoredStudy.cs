using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.Entities;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents entity used to store a study, the whole work process from initiating a research to narrowing
    ///     down relevant research evidence.
    ///     A study consists of diﬀerent phases where data is continuously synthesized and approved by users with different
    ///     roles.
    /// </summary>
    public class StoredStudy : IEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Classification { get; set; } // Study type 

        [Required]
        [StringLength(400)]
        public string Description { get; set; }

        public virtual ICollection<StoredPhase> Phases { get; set; }

        [Required]
        public List<int> UserId { get; set; }

        [Key]
        public int Id { get; set; }
    }
}