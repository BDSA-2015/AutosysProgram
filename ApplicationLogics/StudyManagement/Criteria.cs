// Criteria.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.StudyManagement
{

    /// <summary>
    /// Criteria that is evaluated throughout the whole lifetime of a givne study. 
    /// By way of example, a criteria could be whether the data is from later than 2005. 
    /// The criteria is used along the way to synthesize the data. 
    /// As opposed to the classiﬁcation criteria that is only used in the end of the study. 
    /// </summary>
    public class Criteria
    {

        /// <summary>
        /// Defines which operation to use for comparison. 
        /// </summary>
        public enum CriteriaOperation
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
        public enum CriteriaType
        {
            Inclusion,
            Exclusion
        }

        public CriteriaType Type { get; set; }

        /// <summary>
        /// The type of comparison used to 
        /// </summary>
        public CriteriaOperation ComparisonType { get; set; }

        /// <summary>
        /// The actual value used to retrieve relevant papers for a given study upon comparison. 
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Can be used to associate a default type of limitation with a certain name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the Criteria purpose and functionality.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// This represents the bibtex tag affected by a given criteria.
        /// By way of example, a tag {Title} could be targetted in the criteria through a string comparison. 
        /// </summary>
        public string Tag { get; set; } // TODO Replace with reference to Tag entity class 
    }

}

        