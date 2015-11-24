using ApplicationLogics.Repository;
using System.Collections.Generic;

namespace ApplicationLogics.StudyManagement
{
    public class Study: IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// The Study's name. Try to keep the name unique
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// What kind of study  is this
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// A quick summary of the study
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// The phases the project has been through and the current phase
        /// </summary>
        public List<Phase> phases { get;  set; }

        
    }
}
