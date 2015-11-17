using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationLogics.StudyManagement
{

    /// <summary>
    /// A datafield is part of a given task and is used to determine how paper content is evaluated.
    /// </summary>
    public class DataField
    {
        public enum Type
        {
            String,
            Boolean, // True or false 
            Enumeration, // Select one item from list 
            Flags, // Select multiple items or none from list 
            Resource // Link to resource 
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public Type FieldType { get; set; }

        public bool IsModifiable { get; set; }

        /// <summary>
        /// Used for Enumeration and Flags data types, a collection of the predefined values.
        /// </summary>
        public string[] TypeInfo { get; set; }

    }

}
