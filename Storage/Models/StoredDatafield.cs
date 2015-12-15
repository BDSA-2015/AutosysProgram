using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
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
        #region Enum helpers  

        public enum DatafieldTypeOptions
        {
            String,
            Boolean, // True or false 
            Enumeration, // Select one item from list. Comma separated
            Flags, // Select multiple items or none from list. Comma separated
            Resource // type such as PDF, JPEG etc.
        }

        /// <summary>
        ///     Used to map the enum Type as a string.
        /// </summary>
        [Column("DatafieldType")]
        public string TypeString
        {
            get { return Type.ToString(); }
            private set { Type = EnumExtensions.ParseEnum<DatafieldTypeOptions>(value); }
        }

        #endregion

        #region Datafield properties 

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        public string IsModifiable { get; set; }

        public DatafieldTypeOptions Type { get; set; }

        /// <summary>
        ///     The value of the data field, which is filled out by a user.
        ///     Strings are used to define field values.
        ///     For all types except <see cref="DatafieldTypeOptions.Flags"/> the array contains a single string
        /// </summary>
        public virtual ICollection<string> FieldData { get; set; } 

        /// <summary>
        ///     For <see cref="DatafieldTypeOptions.Enumeration" /> and <see cref="DatafieldTypeOptions.Flags" /> data types, a collection of the
        ///     predefined values.
        /// </summary>
        public virtual ICollection<string> TypeInfo { get; set; }

        #endregion

        #region Keys 

        public virtual StoredStudy Study { get; set; }

        public virtual StoredTaskRequest Task { get; set; }

        public virtual StoredPaper Paper { get; set; }

        public virtual StoredPhase Phase { get; set; }

        [Key]
        public int Id { get; set; }

        #endregion

    }

}