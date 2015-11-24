// TagValidator.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement
{
    public class TagValidator : IValidator
    {
        private readonly Dictionary<ITag, TagChecker> _checkers;
        private readonly TagChecker _defaultChecker = new TagChecker();

        public TagValidator(Dictionary<ITag, TagChecker> checkers = null)
        {
        }

        public bool IsItemValid(ITag item)
        {
            throw new NotImplementedException();
        }
    }
}