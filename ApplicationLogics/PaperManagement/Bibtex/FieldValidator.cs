using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class FieldValidator
    {
        readonly Dictionary<EnumField, IFieldChecker> _checkers;
        readonly IFieldChecker _defaultChecker = new DefaultFieldChecker();
    
        public FieldValidator(Dictionary<EnumField, IFieldChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<EnumField, IFieldChecker>();
        }

        public bool IsFieldValid(string fieldData, EnumField type)
        {
            throw new NotImplementedException();
        }
    }
}
