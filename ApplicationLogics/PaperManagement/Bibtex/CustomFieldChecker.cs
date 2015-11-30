using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for creating FieldCheckers with a custom designed regex
    /// </summary>
    public class CustomFieldChecker
    {
        private readonly Regex _regex;

        public CustomFieldChecker(string pattern)
        {
            _regex = new Regex(pattern);
        }

        public bool Validate(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException("The given bibtex field cannot be null or empty");
            }
            return _regex.IsMatch(tag);
        }
    }
}
