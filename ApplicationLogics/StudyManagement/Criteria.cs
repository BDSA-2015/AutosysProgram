// Criteria.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{

    /// <summary>
    /// This class represents ... in a ... and is used in ... to ...
    /// </summary>
    public class Criteria : IEntity
    {
        public enum CriteriaOperation { NoteDefined,Less,equal, Greater}

        //Used for serialization 
        public Criteria() { }
       
        public string Name { get; set; }


        public string Description { get; set; }

        /// <summary>
        /// The operator which determin the relation between variable1 and variable2
        /// </summary>
        public CriteriaOperation ComparisonSign { get; set; }
        
        /// <summary>
        /// First variable which is comapared with the second variable based on the the Criteria option.
        /// </summary>
        public DataField variable1 { get; set; }
        /// <summary>
        /// First second variable which is comapared with the first variable based on the the Criteria option.
        /// </summary>
        public DataField variable2 { get; set; }
        public int Id { get; set; }
    }
}