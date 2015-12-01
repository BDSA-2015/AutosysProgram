using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class FieldValidator
    {
        private readonly Dictionary<DefaultEnumField, IFieldChecker> _checkers;
        private readonly IFieldChecker _defaultChecker = new DefaultFieldChecker();
    
        public FieldValidator(Dictionary<DefaultEnumField, IFieldChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<DefaultEnumField, IFieldChecker>();
        }

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
