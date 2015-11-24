using System.Collections.Generic;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Task : IEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// Determines task states; initialized, in progress or completed
        /// </summary>
        public enum Progress { NotStarted, Started, Done }

        public enum TaskType {FillOutDataFields, HandleConflictingDatafields }

        public string Description { get; set; }
 
        private List<DataField> NonModifiableDatafields { get; set; }

        public List<DataField> ModifiableDatafields {  get;  set; } 

    }

}
