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

        //[Required] //nuGet not working
        public string Name { get; set; }

        public string Description { get; set; }

        public Type FieldType { get; set; }

        /// <summary>
        /// Used for <see cref="Type.Enumeration"/> and <see cref="Type.Flags"/> data types, a collection of the predefined values.
        /// </summary>
        public string[] TypeInfo { get; set; }

        /// <summary>
        /// This property holds the data for the field and can be used to provide default data to the user, as well as by the user to submit the task.
        /// The data this field holds depends on the data type.
        /// For all but <see cref="Type.Flags" /> this array contains just one element; the representation of the object for that data type (see <see cref="Type" />).
        /// For <see cref="Type.Flags" /> it can contain several flags, either existing ones listed in <see cref="TypeInfo" />, or new ones.
        /// For <see cref="Type.Resource" /> it contains a JSON representation of <see cref="Resource" />.
        /// </summary>
        public string[] Data { get; set; }

    }

}
