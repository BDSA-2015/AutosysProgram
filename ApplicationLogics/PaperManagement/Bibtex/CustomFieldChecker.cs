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
    /// Class for creating a custom field checker for bibtex fields based on a regular expression given by a client.
    /// This makes it possible for the client to define filter criteria for bibtex files when importing them
    /// </summary>
    public class CustomFieldChecker : IFieldChecker
    {
        private Regex _regex;

        public CustomFieldChecker(string regex)
        {
            _regex = new Regex(regex);
        }


        public bool Validate(string field)
        {
            return _regex.IsMatch(field);
        }
    }
}
