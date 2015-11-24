using System;
using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement
{
    public class TagValidator : IValidator
    {
        readonly Dictionary<ITag, TagChecker> _checkers;
        readonly TagChecker _defaultChecker = new TagChecker();
    
        public TagValidator(Dictionary<ITag, TagChecker> checkers = null)
        {
        }

        public bool IsItemValid(ITag item)
        {
            throw new NotImplementedException();
        }
    }
}
