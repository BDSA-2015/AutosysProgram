using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{

    /// <summary>
    /// This class represents the entity used to store Roles that define what tasks a user receives in a given phase.
    /// </summary>
    public class StoredRole : IEntity
    {
        [Key]
        public int Id { get; set; }

        public enum Type
        {
            Validator,
            Reviewer
        }
        
        public Type RoleType { get; set; }

        /// <summary>
        /// Used to map the enum Type as a string. 
        /// </summary>
        [Required]
        [Column("Type")]
        public string TypeString
        {
            get { return RoleType.ToString(); }
            private set { RoleType = EnumExtensions.ParseEnum<Type>(value); }
        }

    }

}
