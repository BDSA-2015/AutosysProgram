using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents a Criteria entity used to synthesize data in a given study.
    /// </summary>
    [Table("Criteria")]
    public class StoredCriteria : IEntity
    {
        /// <summary>
        ///     Defines which operation to use for comparison.
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
        ///     Used to determine whether the criteria should include or exclude data.
        /// </summary>
        public enum Type
        {
            Inclusion,
            Exclusion
        }

        [NotMapped]
        public Type CriteriaType { get; set; }

        [NotMapped]
        public Operation ComparisonType { get; set; }

        /// <summary>
        ///     Used to map the enum FilterType as a string.
        /// </summary>
        [Required]
        [Column("CriteriaType")]
        public string FilterTypeString
        {
            get { return CriteriaType.ToString(); }
            private set { CriteriaType = EnumExtensions.ParseEnum<Type>(value); }
        }

        /// <summary>
        ///     Used to map the enum FilterType as a string.
        /// </summary>
        [Required]
        [Column("ComparisonType")]
        public string TypeString
        {
            get { return ComparisonType.ToString(); }
            private set { ComparisonType = EnumExtensions.ParseEnum<Operation>(value); }
        }

        /// <summary>
        ///     The actual value used to retrieve relevant papers for a given study upon comparison.
        /// </summary>
        public string Value { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)] // Used to delete Criteria by name in Phase 
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        /// <summary>
        ///     This represents a file tag e.g. a bibtex entry, which will be affected by the criteria.
        ///     The value of the Tag should be the same as the value in the Criteria for the tag to be either included or excluded.
        ///     By way of example, a tag {Title} could be targeted in the criteria through a string comparison.
        /// </summary>
        public string Tag { get; set; }

        [Key]
        public int Id { get; set; }
    }
}