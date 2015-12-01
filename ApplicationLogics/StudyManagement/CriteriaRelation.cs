using System;
using System.Reflection;
using Microsoft.VisualBasic;

namespace ApplicationLogics.StudyManagement
{
    public class CriteriaRelation
    {
        /// <summary>
        /// The criterias relation. Less and Greater refer to a criteria which can be compared numericly, while Equals refer to either a string comparison or a numerical comparison.
        /// </summary>
        public Criteria.CriteriaOperation ComparionsonType { get; set; }
        
        /// <summary>
        /// The Criteiria which will be used to choose which papers are relevant for the study
        /// </summary>
        public string Criteria { get; set; }
        public CriteriaRelation()
        { }

    }
}