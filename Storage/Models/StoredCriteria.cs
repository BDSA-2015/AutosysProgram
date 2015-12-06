using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    
    /// <summary>
    /// This class represents a Criteria entity used to synthesize data in a given study. 
    /// </summary>
    [Table("Criteria")]
    public class StoredCriteria : IEntity
    {

        /// <summary>
        /// Defines which operation to use for comparison. 
        /// </summary>
        public enum Operation
        {
            Less, // Numerical comparison 
            Equals, // String comparison 
            Greater, // Numerical comparison 
            Contains,
            Regex // Not currently supported 
        }

        /// <summary>
        /// Used to determine whether the criteria should include or exclude data.
        /// </summary>
        public enum Type
        {
            Inclusion,
            Exclusion
        }

        [Key]
        public int Id { get; set; }

        [NotMapped]
        public Type FilterType { get; set; }

        [NotMapped]
        public Operation ComparisonType { get; set; }

        /// <summary>
        /// Used to map the enum FilterType as a string. 
        /// </summary>
        [Required]
        [Column("FilterType")]
        public string FilterTypeString
        {
            get { return FilterType.ToString(); }
            private set { FilterType = EnumExtensions.ParseEnum<Type>(value); }
        }

        /// <summary>
        /// Used to map the enum FilterType as a string. 
        /// </summary>
        [Required]
        [Column("ComparisonType")]
        public string TypeString
        {
            get { return ComparisonType.ToString(); }
            private set { ComparisonType = EnumExtensions.ParseEnum<Operation>(value); }
        }

        /// <summary>
        /// The actual value used to retrieve relevant papers for a given study upon comparison. 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// This represents the bibtex tag affected by a given criteria.
        /// By way of example, a tag {Title} could be targetted in the criteria through a string comparison. 
        /// </summary>
        public virtual StoredTag Tag { get; set; } // TODO Replace with reference to Tag entity class 

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)] // Used to delete Criteria by name in Phase 
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public virtual StoredDataField DataField { get; set; }


    }

}
