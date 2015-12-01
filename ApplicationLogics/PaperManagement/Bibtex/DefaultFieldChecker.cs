using System;
using System.Text.RegularExpressions;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for creating a default field checker which will be used whenever a client does not specify any 
    /// custom field checkers
    /// </summary>
    public class DefaultFieldChecker : IFieldChecker
    {
        //Matches all strings without a new line at the beginning or in between characters.
        readonly Regex _r = new Regex("^.*$");

        /// <summary>
        /// Method to validate bibtex fields when parsing bitex files to Paper objects
        /// </summary>
        /// <param name="field">Bibtex field to be validated</param>
        /// <returns>True if the field is valid otherwise false</returns>
        public bool Validate(string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                throw new ArgumentNullException("The given bibtex field cannot be null or empty");
            }
            return _r.IsMatch(field);
        }
    }
}
