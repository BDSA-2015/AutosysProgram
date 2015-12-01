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
    /// This class represents the entity used to store Roles that define what tasks a user receives in a given phase.
    /// </summary>
    public class StoredRole : IEntity
    {
        public enum Type
        {
            Validator,
            Reviewer
        }

        [Key]
        public int Id { get; set; }

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
