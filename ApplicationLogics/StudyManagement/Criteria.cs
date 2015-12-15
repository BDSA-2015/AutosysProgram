// Criteria.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     Criteria that is evaluated throughout the whole lifetime of a given study.
    ///     By way of example, a criteria could be whether the data is from later than 2005.
    ///     The criteria is used along the way to filter the data.
    /// </summary>
    public class Criteria
    {
        /// <summary>
        ///     Defines which operation to use for comparison.
        /// </summary>
        public enum Operation
        {
            Less, // Numerical comparison 
            Equals, // String comparison 
            Greater, // Numerical comparison

            //Not implemented
            Contains,
            Regex // Not currently supported 
        }

        /// <summary>
        ///     The possible types of a Criteria
        /// </summary>
        public enum Type
        {
            Inclusion,
            Exclusion
        }

        /// <summary>
        ///     Used to determine whether the criteria should include or exclude data.
        /// </summary>
        public Type CriteriaType { get; set; }

        /// <summary>
        ///     Used to determine how the criteria should be evaluated
        /// </summary>
        public Operation ComparisonType { get; set; }

        /// <summary>
        ///     Can be used to associate a default type of limitation with a certain name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The actual value of the criteria used to check against when evaluating papers for a given study.
        ///     Boolean expressions will have the value "true" or "false"
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     A short description of what the criteria is evaluating
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     This represents a file tag e.g. a bibtex entry, which will be affected by the criteria.
        ///     The value of the Tag should be the same as the value in the Criteria for the tag to be either included or excluded.
        ///     By way of example, a tag {Title} could be targeted in the criteria through a string comparison.
        /// </summary>
        public string Tag { get; set; }
    }
}