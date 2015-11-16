using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Task : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// What state is the task in. Has it not been initialized yet, is it in progress or has it been completed
        /// </summary>
        public enum Types { NotStarted, Started, Done }

        // Data fields, still do not know data type?
        public object PropertyValue { get; set; }
    }
}
