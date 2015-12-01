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
    public  class CriteriaHandler
    {




        /// <summary>
        /// Create an empty criteria. Specify its purpose with AddRelation method
        /// </summary>
         public Criteria CreateCriteria(string name, string description)
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
        public void setCriteria(Criteria critera, CriteriaRelation itemToSearchFor)
        {
            critera.Requirement = itemToSearchFor;
        }


        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which contains this string
        /// </summary>
        public void SetSearchCriteria_ContainsString(string bibTexTagName, string substring)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which equals this string.
        /// </summary>
        public void SetSearchCriteria_equals(string bibTexTagName, string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which less than the given value.
        /// </summary>
        public void SetSearchCriteria_LessThan(string bibTexTagName, int value)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value which Greater than the given value.
        /// </summary>
        public void SetSearchCriteria_GreaterThan(string bibTexTagName, int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value Which match .
        /// </summary>
        public void SetSearchCriteria_Regex(string bibTexTagName, string substring)
        {
            throw new NotImplementedException();
        }
    }
}
