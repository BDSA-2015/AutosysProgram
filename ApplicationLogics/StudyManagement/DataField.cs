using System;


namespace ApplicationLogics.StudyManagement
{

    /// <summary>
    /// A datafield is part of a given task and is used to determine how paper content is evaluated.
    /// </summary>
    public class DataField
    {
        public DataField(string name, string description, Type fieldType, string fieldValue, bool isModifiable)
        {
            if(string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description) && string.IsNullOrEmpty(fieldValue))
                throw new ArgumentNullException("Please enter valid arguments. Null, whitespaces and empty strings are not allowed.");
            _name = name;
            _description = description;
            _fieldType = fieldType;
            _fieldValue = fieldValue;
            IsModifiable = isModifiable;
        }

        public enum Type
        {
            String,
            Boolean, // True or false 
            Enumeration, // Select one item from list. Comma seperated
            Flags, // Select multiple items or none from list. Comma seperated
            Resource // type such as PDF, JPEG etc.
        }

        public string Name
        {
            get { return _name; }
            set {if(IsModifiable) _name = value; }
        }
        private string _name;

        public string Description
        {
            get { return _description; }
            set { if (IsModifiable) _description = value; }
        }
        private string _description;


        public Type FieldType
        {
            get { return _fieldType; }
            set { if (IsModifiable) _fieldType = value;}
        }
        private Type _fieldType;


        /// <summary>
        /// We use string to define field value. We use comma serperation
        /// when using enumerarion and flags
        /// </summary>
        public string FieldValue
        {
            get { return _fieldValue; }
            set { if (IsModifiable) _fieldValue = value; }
        }
        private string _fieldValue;

        public bool IsModifiable { get; }

    }

}
