using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class PaperValidator
    {
        /// <summary>
        /// A collection of bibliography entries and their associated Paper checkers
        /// </summary>
        readonly Dictionary<EnumEntry, IPaperChecker> _checkers;
        /// <summary>
        /// A default Paper checker to make sure a checker always exists for a PaperValidator
        /// </summary>
        readonly IPaperChecker _defaultChecker = new DefaultPaperChecker();

        public PaperValidator(Dictionary<EnumEntry, IPaperChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<EnumEntry, IPaperChecker>();
        }

        public bool IsPaperValid(Paper paper)
        {
            if (paper == null)
            {
                throw new ArgumentNullException("The given Paper cannot be null");
            }
            return _checkers.ContainsKey(paper.Type)
                ? _checkers[paper.Type].Validate(paper)
                : _defaultChecker.Validate(paper);
        }
    }
}
