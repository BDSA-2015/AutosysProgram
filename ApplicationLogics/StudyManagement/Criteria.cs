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
        public enum CriteriaOperation { NoteDefined,Less,Equal, Greater}

        //Used for serialization 
        public Criteria() { }
       
        /// <summary>
        /// The Criteria Nam, Can be used to associate a defualt type of limitation with a certain name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the Criterias purpose.
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// The object the exclusion/inclusion criteria centers around. 
        /// </summary>
        public DataField SearchItem { get; set; }
        /// <summary>
        /// A variable which gives context to the searchItem. fx Has the search item more quantity than x?
        /// </summary>
        public CriteriaLimitation Limitation { get; set; }

        /// <summary>
        /// This value determins the relation between the SearchItem and the limitation value. Fx is Less, then Criteria is required to be less than the Limitation value
        /// </summary>
        public CriteriaOperation LimitationType { get; set; }

        

        
        public int Id { get; set; }
    }
}