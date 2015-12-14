using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents a data field entity.
    ///     The datafield is used as part of a criteria to include and exclude paper content.
    /// </summary>
    [Table("DataField")]
    public class StoredDataField : IEntity
    {
        public enum Type
        {
            String,
            Boolean, // True or false 
            Enumeration, // Select one item from list. Comma separated
            Flags, // Select multiple items or none from list. Comma separated
            Resource // type such as PDF, JPEG etc.
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(400)]
        public string Description { get; set; }

        [NotMapped]
        public Type FieldType { get; set; }

        /// <summary>
        ///     Used to map the enum Type as a string.
        /// </summary>
        [Required]
        [Column("Type")]
        public string TypeString
        {
            get { return FieldType.ToString(); }
            private set { FieldType = EnumExtensions.ParseEnum<Type>(value); }
        }


        /// <summary>
        ///     We use string to define field values.
        ///     We use comma serperation when using enumerarion and flags.
        /// </summary>
        /// Todo Should this be on a column for itself? Dennis
        public string FieldValue { get; set; }

        public string IsModifiable { get; set; }

        /// <summary>
        ///     For <see cref="DataType.Enumeration" /> and <see cref="DataType.Flags" /> data types, a collection of the
        ///     predefined values.
        /// </summary>
        public string[] TypeInfo { get; set; }

        [Key]
        public int Id { get; set; }
    }
}