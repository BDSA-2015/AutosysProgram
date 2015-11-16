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
        public enum Progress { NotStarted, Started, Done }

        public enum TaskType {FillOutDataFields, HandleConflictingDatafields }

        /// <summary>
        /// A brief description of the task
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// What kind of task is this
        /// </summary>
       

        private List<DataField> NonModifiableDatafields { get; set; }
        public List<DataField> ModifiableDatafields {  get;  set; } //TODO CONSIDER IF WE WANT TO RETURN THE WHOLE LIST.

        private List<DataField> _nonModifiableDatafields;

        public IEnumerable<DataField> getNonModifiableDatafields()
        {
            throw new NotImplementedException();
        }

        public class DataField
        {
            string Name { get; set; }
            public bool IsModifiable { get; private set; }

            public Object Value { get; private set; }

            public DataField(string Name, Object value, bool IsModifiable)
            {
                throw new NotImplementedException();
            }

            public void setValue(Object value)
            {
                throw new NotImplementedException();
                if (IsModifiable)
                {


                }

            }

        }
    }
}
