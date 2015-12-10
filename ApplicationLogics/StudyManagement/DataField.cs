// DataField.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     A datafield is part of a given task and is used to determine how paper content is evaluated.
    /// </summary>
    public class DataField
    {
        public enum Type
        {
            String,
            Boolean, // True or false 
            Enumeration, // Select one item from list. Comma separated
            Flags, // Select multiple items or none from list. Comma separated
            Resource // type such as PDF, JPEG etc.
        }

        private string _description;
        private Type _fieldType;
        private string _fieldValue;
        private string _name;

        public DataField(string name, string description, Type fieldType, string fieldValue, bool isModifiable)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(fieldValue))
                throw new ArgumentNullException(
                    "Please enter valid arguments. Null, whitespaces and empty strings are not allowed.");
            _name = name;
            _description = description;
            _fieldType = fieldType;
            _fieldValue = fieldValue;
            IsModifiable = isModifiable;
        }

        public string Name
        {
            get { return _name; }
            set { if (IsModifiable) _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { if (IsModifiable) _description = value; }
        }


        public Type FieldType
        {
            get { return _fieldType; }
            set { if (IsModifiable) _fieldType = value; }
        }


        /// <summary>
        ///     We use string to define field values.
        ///     We use comma serperation when using enumerarion and flags.
        /// </summary>
        public string FieldValue
        {
            get { return _fieldValue; }
            set { if (IsModifiable) _fieldValue = value; }
        }

        public bool IsModifiable { get; }
    }
}