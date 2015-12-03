using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public int[] UserIds { get; set; } // TODO convert string to int array like below 

        /*
            public string InternalData { get; set; }
            public double[] Data
            {
                get
                {
                    return Array.ConvertAll(InternalData.Split(';'), Double.Parse);                
                }
                set
                {
                    _data = value;
                    InternalData = String.Join(";", _data.Select(p => p.ToString()).ToArray());
                }
            }
        */

        [StringLength(400)]
        public string Metadata { get; set; }

    }

}
