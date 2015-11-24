using System.Collections.Generic;
using ApplicationLogics.Repository;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ProtocolManagement
{
    /// <summary>
    /// This class represents the Research Protocol used to configure a given study.
    /// </summary>
    public class Protocol : IEntity
    {
        // Which other attributes does a protocol contain?
        public int Id { get; set; }
        public List<Criteria> InclusionCriteria { get; set; }
        public List<Criteria> ExclusionCriteria { get; set; } 
        public string Description { get; set; } // Describes protocol goal
    }
}
