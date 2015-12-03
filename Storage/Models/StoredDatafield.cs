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
    /// This class represents a data field entity.
    /// The datafield is used as part of a criteria to include and exclude paper content. 
    /// </summary>
    [Table("DataField")]
    public class StoredDataField : IEntity
    {

        public enum Type
        {
            String,
            Boolean,
            Enumeration,
            Flags,
            Resource
        }
        
        [Key]
        public int Id { get; set; }

        [Required][StringLength(50)]
        public string Name { get; set; }

        [Required][StringLength(400)]
        public string Description { get; set; }

        [NotMapped]
        public Type FieldType { get; set; }

        /// <summary>
        /// Used to map the enum Type as a string. 
        /// </summary>
        [Required][Column("Type")]
        public string TypeString
        {
            get { return FieldType.ToString(); }
            private set { FieldType = EnumExtensions.ParseEnum<Type>(value); }
        }

        // TODO Boolean conversion in EF? 
        public bool IsModifiable { get; set; }

    }

}
