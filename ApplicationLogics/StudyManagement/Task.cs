// Task.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System.Collections.Generic;
using ApplicationLogics.Repository;

namespace ApplicationLogics.StudyManagement
{
    public class Task : IEntity
    {
        /// <summary>
        ///     Determines task states; initialized, in progress or completed
        /// </summary>
        public enum Progress
        {
            NotStarted,
            Started,
            Done
        }

        public enum TaskType
        {
            FillOutDataFields,
            HandleConflictingDatafields
        }

        public string Description { get; set; }

        private List<DataField> NonModifiableDatafields { get; set; }

        public List<DataField> ModifiableDatafields { get; set; }
        public int Id { get; set; }
    }
}