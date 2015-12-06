using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for validating Papers to be parsed in a BibtexParser object
    /// </summary>
    public class PaperValidator
    {
        /// <summary>
        /// A collection of bibliography entries and their associated Paper checkers
        /// </summary>
        readonly Dictionary<string, IPaperChecker> _checkers;
        /// <summary>
        /// A default Paper checker to make sure a checker always exists for a PaperValidator
        /// </summary>
        readonly IPaperChecker _defaultChecker = new PaperChecker();

        public PaperValidator(Dictionary<string, IPaperChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<string, IPaperChecker>();
        }

        /// <summary>
        /// Method for validating Papers for parsing in a BibtexParser object
        /// </summary>
        /// <param name="paper">The Paper to be validated for parsing</param>
        /// <returns>True if the Paper is valid false otherwise</returns>
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
