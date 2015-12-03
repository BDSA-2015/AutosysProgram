using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for creating FieldCheckers with a custom designed regex
    /// </summary>
    public class CustomFieldChecker : IFieldChecker
    {
        //Regular expression to for matching a bibtex field
        private readonly Regex _regex;

        public CustomFieldChecker(string pattern)
        {
            _regex = new Regex(pattern);
        }

        /// <summary>
        /// Method to validate bibtex fields when parsing bitex files to Paper objects
        /// </summary>
        /// <param name="field">The bibtex field to validate</param>
        /// <returns>True if the field is valid otherwise false</returns>
        public bool Validate(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException("The given bibtex field cannot be null or empty");
            }
            return _regex.IsMatch(field);
        }
    }
}
