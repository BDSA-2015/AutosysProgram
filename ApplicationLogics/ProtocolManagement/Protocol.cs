using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;

namespace ApplicationLogics.ExportManagement
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
