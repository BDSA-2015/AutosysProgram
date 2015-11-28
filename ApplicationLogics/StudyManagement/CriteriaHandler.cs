using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    public static class CriteriaHandler
    {


        

        /// <summary>
        /// Create an empty criteria. Specy its purpose with AddRelation
        /// </summary>
        static  Criteria CreateCriteria(string name, string description)
        {
            var criteria = new Criteria();
            criteria.Name = name;
            criteria.Description = description;

            return criteria;

            throw new NotImplementedException(); //Should we assign an ID at this state
        }


        /// <summary>
        /// Defines a Criteria which search for a specific item
        /// </summary>
        /// <param name="critera">The Criteria you which to modify</param>
        /// <param name="itemToSearchFor">THe item you you wish to search for</param>
        static void SetCriteriaToSearchForASpecificItem(Criteria critera, DataField itemToSearchFor)
        {
            critera.LimitationType = Criteria.CriteriaOperation.Equal;
            critera.SearchItem = itemToSearchFor;
            critera.Limitation = null;
        }


        /// <summary>
        /// Define the criteria as a boolean equation which include/ exclude material based on the year.
        /// </summary>
        static void SetYearLimitation(Criteria criteria, DataField searchItem, Criteria.CriteriaOperation relation,
            DateTime timeLimitation)
        {
            if (relation == Criteria.CriteriaOperation.Equal)
                throw new ArgumentException("Not accepted type, can't compare a year to itself");

            criteria.SearchItem = searchItem;
            criteria.LimitationType = relation;
            criteria.Limitation = new CriteriaLimitation(timeLimitation);
        }

        /// <summary>
        /// Define a critreria which is based of a quantity problem. The criteria is satisfied if the criteria lives up to the boolian equation
        /// </summary>
        static void SetQuantityLimitation(Criteria criteria, DataField seachItem,
            Criteria.CriteriaOperation limitationType, int limitation)
        {
            criteria.SearchItem = seachItem;
            criteria.LimitationType = limitationType;
            criteria.Limitation = new CriteriaLimitation(limitation);
        }
    }

}
