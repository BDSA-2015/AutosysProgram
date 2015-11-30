using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class FieldValidator
    {
        private readonly Dictionary<EnumField, IFieldChecker> _checkers;
        private readonly IFieldChecker _defaultChecker = new DefaultFieldChecker();
    
        public FieldValidator(Dictionary<EnumField, IFieldChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<EnumField, IFieldChecker>();
        }

        public bool IsFieldValid(string fieldData, EnumField type)
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
