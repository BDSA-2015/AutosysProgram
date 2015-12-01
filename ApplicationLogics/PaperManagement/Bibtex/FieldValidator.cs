using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for validating the fields of a bibtex file
    /// If no dictionary of custom field checkers is given a default field checker will be used
    /// to validate the bibtex fields
    /// </summary>
    public class FieldValidator
    {
        //Holds fields and the associated checkers to be used when validating them
        private readonly Dictionary<DefaultEnumField, IFieldChecker> _checkers;

        //Default field checker used when non is specified in the constructor
        private readonly IFieldChecker _defaultChecker = new DefaultFieldChecker();
    
        public FieldValidator(Dictionary<DefaultEnumField, IFieldChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<DefaultEnumField, IFieldChecker>();
        }

        /// <summary>
        /// Method for validating the data associated with a specific bibtex field
        /// </summary>
        /// <param name="fieldData">The data in the bibtex file associated with the bibtex field in the file</param>
        /// <param name="type">The type of the bibtex field</param>
        /// <returns>True if the data of the bibtex field is valid otherwise false</returns>
        public bool IsFieldValid(string fieldData, DefaultEnumField type)
        {
            if (string.IsNullOrEmpty(fieldData))
            {
                throw new ArgumentNullException("The given field data cannot be null or empty");
            }

            return _checkers.ContainsKey(type)
                ? _checkers[type].Validate(fieldData)
                : _defaultChecker.Validate(fieldData);
        }
    }
}
