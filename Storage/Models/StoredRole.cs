using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents the entity used to store Roles that define what tasks a user receives in a given phase.
    /// </summary>
    public class StoredRole : IEntity
    {

        public TypeOptions Type { get; set; }

        [Key]
        public int Id { get; set; }

        #region Enum Helpers

        public enum TypeOptions
        {
            Validator,
            Reviewer
        }

        /// <summary>
        ///     Used to map the enum Type as a string.
        /// </summary>
        [Column("Type")]
        public string TypeString
        {
            get { return Type.ToString(); }
            private set { Type = EnumExtensions.ParseEnum<TypeOptions>(value); }
        }

        #endregion

    }

}