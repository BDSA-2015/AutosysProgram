using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    /// This class is used to create new Criteria. 
    /// </summary>
    public  class CriteriaFactory
    {
        
        /// <summary>
        /// Create an empty criteria. Specify its purpose with AddRelation method
        /// </summary>
         public Criteria CreateEmptyCriteria(string name, string description)
        {
            EmptyStringChecker(name);
            EmptyStringChecker(description);

            var criteria = new Criteria
            {
                Name = name,
                Description = description
            };

            return criteria;
        }

        /// <summary>
        /// Defines a search criteria used to either include or exclude data. 
        /// </summary>
        /// <param name="criteria">
        /// Criteria set for search. 
        /// </param>
        /// <param name="type">
        /// Either an inclusion or exclusion criteria. 
        /// </param>
        public void SetSearchCriteria(Criteria criteria, Criteria.Type type)
        {
            criteria.FilterType = type;
        }


        /// <summary>
        /// Set the Criteria for data (paper) containing a bibtex tag with a value containing the string.
        /// </summary>
        /// <param name="criteria">
        /// Criteria used to search in data with. 
        /// </param>
        /// <param name="bibTexTagName">
        /// Name of a given bibtex tag that we want to check. 
        /// </param>
        /// <param name="substring">
        /// The string checked for if contained in field from tag. 
        /// </param>
        public void SetSearchCriteria_ContainsString(Criteria criteria, string bibTexTagName, string substring)
        {
            EmptyStringChecker(substring);

            criteria.Tag = bibTexTagName;
            criteria.ComparisonType = Criteria.Operation.Contains;
            criteria.Value = substring;           
        }

        /// <summary>
        /// Set the Criteria to search for papers, which have a bibtex tag with a value which equals this string.
        /// </summary>
        /// <param name="criteria">
        /// Criteria used to search with. 
        /// </param>
        /// <param name="bibTexTagName">
        /// Name of bibtex tag. 
        /// </param>
        /// <param name="value">
        /// Value to compare with. 
        /// </param>
        public void SetSearchCriteria_Equals(Criteria criteria, string bibTexTagName, string value)
        {
            EmptyStringChecker(value);

            criteria.Tag = bibTexTagName;
            criteria.ComparisonType = Criteria.Operation.Equals;
            criteria.Value = value;
        }

        // TODO explain documentation and difference of int and string value in overloaded method 
        public void SetSearchCriteria_Equals(Criteria criteria, string bibTexTagName, int value) 
        {
            criteria.Tag = bibTexTagName;
            criteria.ComparisonType = Criteria.Operation.Equals;
            criteria.Value = ""+value;
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value less than the given value.
        /// </summary>
        /// <param name="criteria">
        /// Criteria used to search with. 
        /// </param>
        /// <param name="bibTexTagName">
        /// The type of bibtex tag used in the Criteria. 
        /// </param>
        /// <param name="value">
        /// Value used to compare with a value within the bibtex tag. 
        /// </param>
        public void SetSearchCriteria_LessThan(Criteria criteria, string bibTexTagName, int value)
        {
            criteria.Tag = bibTexTagName;
            criteria.ComparisonType = Criteria.Operation.Less;
            criteria.Value = ""+value;
        }

        /// <summary>
        /// Set the Criteria to search for papers containing a bibtex tag with a value greater than the given value.
        /// </summary>
        /// <param name="criteria">
        /// Criteria used to search with. 
        /// </param>
        /// <param name="bibTexTagName">
        /// Bibtex tag containing a value to compare with. 
        /// </param>
        /// <param name="value">
        /// Value used to compare with other value within bibtex tag. 
        /// </param>
        public void SetSearchCriteria_GreaterThan(Criteria criteria, string bibTexTagName, int value)
        {
            criteria.Tag = bibTexTagName;
            criteria.ComparisonType = Criteria.Operation.Greater;
            criteria.Value = "" + value;
        }

        /// <summary>
        /// Set the Criteria to search for papers which have a bibtex tag with a value that match a certain pattern.
        /// </summary>
        /// <param name="critera">
        /// - Insert here - 
        /// </param>
        /// <param name="bibTexTagName">
        /// - Insert here - 
        /// </param>
        /// <param name="regexPattern">
        /// - Insert here - 
        /// </param>
        public void SetSearchCriteria_Regex(Criteria critera, string bibTexTagName, string regexPattern)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Throws an argumentException if a. empty string is found.
        /// </summary>
        /// <param name="inputString"></param>
        private void EmptyStringChecker(string inputString)
        {
            if(inputString.Length==0)
                throw new ArgumentException("The string cannot be empty.");
        }

    }

}
