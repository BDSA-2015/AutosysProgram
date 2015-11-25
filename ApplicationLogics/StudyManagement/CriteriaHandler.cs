using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.StudyManagement
{
    class CriteriaHandler
    {



        public CriteriaHandler()
        {
            
        }
        /// <summary>
        /// Create an empty criteria. Specy its purpose with AddRelation
        /// </summary>
        public Criteria CreateCrietria(string name, string description)
        {
            var criteria = new Criteria();
            criteria.Name = name;
            criteria.Description = description;

            throw new NotImplementedException(); //Should we assign an ID at this state
        }

        /// <summary>
        /// Add a specific purpose for the Criteria.
        /// </summary>
        /// <param name="criteria">The criteria object you wish to modify</param>
        /// <param name="variable1">A object which has a relation with variable2</param>
        /// <param name="relation"> A relation which defines variable1 variable2 (Less,Greater,Equal)</param>
        /// <param name="variable2">A object which has a relation with variable1 </param>
        public void AddRelation(Criteria criteria, DataField variable1, Criteria.CriteriaOperation relation, DataField variable2)
        {
            //Aboard if variables are not compatible. Fx can't compare two strings 
            throw new NotImplementedException();

            criteria.variable1 = variable1;
            criteria.ComparisonSign = relation;
            criteria.variable2 = variable2;
        }
        public bool IsCriteriaSatisfied(Criteria criteria)
        {

            CheckCriteriaIsReadyForEvaluation(criteria);
            switch(criteria.ComparisonSign)
            {

                default:
                    throw new ArgumentException($"Criteria contained {criteria.ComparisonSign} which is unknown to CriteriaHandler class");
                    break;
            }

            throw new NotFiniteNumberException();
        }

        /// <summary>
        /// Throws an error if Criteria is not ready to be evaluated yet.
        /// </summary>
        /// <param name="criteria"></param>
        private void CheckCriteriaIsReadyForEvaluation(Criteria criteria)
        {
            if (criteria.variable1 == null)
                throw new ArgumentException("Criteria has not been properly defined yet, please specify variable1 first");
            if (criteria.variable2 == null)
                throw new ArgumentException("Criteria has not been properly defined yet, please specify variable2 first");
            if (criteria.ComparisonSign == Criteria.CriteriaOperation.NoteDefined)
                throw new ArgumentException("Criteria has not been properly defined yet, please specify ComparisonSign first");
        }


        private void isLessThan(Criteria criteria)
        {
            var argumentType = criteria.variable1.FieldType;
            switch(argumentType)
            {


                default: throw new ArgumentException($"Unknown FieldType: {argumentType}");
            }
        }

       public bool intComparer(Criteria criteria)
        {

            switch()
            
            throw new NotImplementedException();
        }

        
    }
}
