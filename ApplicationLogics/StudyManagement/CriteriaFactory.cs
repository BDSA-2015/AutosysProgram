using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    /// This class is meant for Creating new Criterias
    /// </summary>
    public  class CriteriaFactory
    {
        


        /// <summary>
        /// Create an empty criteria. Specify its purpose with AddRelation method
        /// </summary>
         public Criteria CreateEmptyCriteria(string name, string description)
        {
            var criteria = new Criteria();
            criteria.Name = name;
            criteria.Description = description;

            return criteria;
        }


        /// <summary>
        /// Defines a Criteria which search for a specific item
        /// </summary>
        /// <param name="critera">The Criteria you which to modify</param>
        /// <param name="itemToSearchFor">THe item you you wish to search for</param>
        public void setSearchCriteria(Criteria critera, CriteriaRelation itemToSearchFor)
        {
            critera.Requirement = itemToSearchFor;
        }


        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which contains this string
        /// </summary>
        public void SetSearchCriteria_ContainsString(Criteria critera, string bibTexTagName, string substring)
        {
            critera.CriteriaTarget = bibTexTagName;
            critera.Requirement.ComparionsonType = Criteria.CriteriaOperation.Contains;
            critera.Requirement.Criteria = substring;           
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which equals this string.
        /// </summary>
        public void SetSearchCriteria_equals(Criteria critera, string bibTexTagName, string value)
        {
            critera.CriteriaTarget = bibTexTagName;
            critera.Requirement.ComparionsonType = Criteria.CriteriaOperation.Equals;
            critera.Requirement.Criteria = value;
        }

        public void SetSearchCriteria_equals(Criteria critera, string bibTexTagName, int value)
        {
            critera.CriteriaTarget = bibTexTagName;
            critera.Requirement.ComparionsonType = Criteria.CriteriaOperation.Equals;
            critera.Requirement.Criteria = ""+value;
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which less than the given value.
        /// </summary>
        public void SetSearchCriteria_LessThan(Criteria critera, string bibTexTagName, int value)
        {
            critera.CriteriaTarget = bibTexTagName;
            critera.Requirement.ComparionsonType = Criteria.CriteriaOperation.Less;
            critera.Requirement.Criteria = ""+value;
        }


        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which Greater than the given value.
        /// </summary>
        public void SetSearchCriteria_GreaterThan(Criteria critera, string bibTexTagName, int value)
        {
            critera.CriteriaTarget = bibTexTagName;
            critera.Requirement.ComparionsonType = Criteria.CriteriaOperation.Greater;
            critera.Requirement.Criteria = "" + value;
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value Which match .
        /// </summary>
        public void SetSearchCriteria_Regex(Criteria critera, string bibTexTagName, string regexPattern)
        {
            throw new NotImplementedException();
        }
    }
}
