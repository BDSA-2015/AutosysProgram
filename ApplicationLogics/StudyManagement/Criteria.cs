// Criteria.cs is a part of Autosys project in BDSA-2015. Created: 12, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.StudyManagement
{

    
    public class Criteria
    {
        //Used for serialization 
        public Criteria()
        {
        }
        /// <summary>
        /// Regex is not currently supported yet
        /// </summary>
        public enum CriteriaOperation {Less,Equals,Greater,Contains, Regex}

        

        /// <summary>
        /// The Criteria name, Can be used to associate a defualt type of limitation with a certain name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the Criterias purpose.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The bibtex tag the critereia the Requirement will effect 
        /// </summary>
        public ITag CriteriaTarget { get; set; }

        /// <summary>
        /// The criteria papers will be sorted after
        /// </summary>
        public CriteriaRelation Requirement { get; set; }


    }
}

        