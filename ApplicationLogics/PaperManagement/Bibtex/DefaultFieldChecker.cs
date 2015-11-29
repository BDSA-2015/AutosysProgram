using System;
using System.Text.RegularExpressions;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class DefaultFieldChecker : IFieldChecker
    {
        //Matches all strings without a new line at the beginning or in between characters.
        readonly Regex _r = new Regex("^.*$");

        public bool Validate(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                throw new ArgumentNullException("The given bibtex field cannot be null or empty");
            }
            return _r.IsMatch(tag);
        }
    }
}
