using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Criteria : IEntity
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Criteria name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short summary of the Criteria
        /// </summary>
        public string Description { get; set; }
    }

}
