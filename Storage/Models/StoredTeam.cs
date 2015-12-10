using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Storage.Repository.Interface;

namespace Storage.Models
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

        public int[] UserIds
        {
            get { return Array.ConvertAll(InternalUserIds.Split(','), Int32.Parse); }
            set { InternalUserIds = String.Join(",", value.Select(ids => ids.ToString().ToArray())); }
        }

        [NotMapped]
        public string InternalUserIds { get; set; } // Converts actual user ids from csv string to int [] in UserIDs. 

        [StringLength(400)]
        public string MetaData { get; set; }

    }

}
