// DataField.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     A data field is part of a given task and is used to determine how paper content is evaluated.
    /// </summary>
    public class DataField
    {
        /// <summary>
        ///     The type of a data field which determines how the data for the field should be gathered
        /// </summary>
        public enum Type
        {
            String,
            Boolean, // True or false 
            
            //Not supported
            Enumeration, // Select one item from list. Comma separated
            Flags, // Select multiple items or none from list. Comma separated
            Resource // type such as PDF, JPEG etc.
        }

        private string _description;
        private Type _fieldType;
        private string[] _fieldData;
        private string _name;

        public DataField(string name, string description, Type fieldType, string[] fieldData, bool isModifiable)
        {
            _name = name;
            _description = description;
            _fieldType = fieldType;
            _fieldData = fieldData;
            IsModifiable = isModifiable;
        }

        public string Name
        {
            get { return _name; }
            set { if (IsModifiable) _name = value; }
        }

        /// <summary>
        ///     Description of the data field, containing the question associated with the data field
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { if (IsModifiable) _description = value; }
        }

        /// <summary>
        ///     The type of a data field which determines how the data for the field should be gathered 
        /// </summary>
        public Type FieldType
        {
            get { return _fieldType; }
            set { if (IsModifiable) _fieldType = value; }
        }


        /// <summary>
        ///     The value of the data field, which is filled out by a user
        ///     Strings are used to define field values.
        ///     For all types except <see cref="Type.Flags"/> the array contains a single string
        /// </summary>
        public string[] FieldData
        {
            get { return _fieldData; }
            set { if (IsModifiable) _fieldData = value; }
        }

        /// <summary>
        ///     Boolean which tells if a data field is modifiable or unmodifiable.
        ///     A modifiable data field is a requested field to be filled out by a user
        ///     An unmodifiable data field is a visible field with information about a file (e.g. author, year, and title)
        /// </summary>
        public bool IsModifiable { get; }


        /// <summary>
        ///     Used for <see cref="Type.Enumeration"/> and <see cref="Type.Flags"/> types
        ///     Defines the possible values where one can be chosen for enumeration or several can be flagged 
        /// </summary>
        public string[] TypeInfo { get; set; }
    }
}