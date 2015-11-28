using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class BibtexParser : IParser
    {
        readonly PaperValidator _validator;

        //TODO Make sure the right regexes are used
        /// <summary>
        /// Regex for matching BibTex items.
        /// </summary>
        readonly Regex _entryRegex = new Regex(@"(?:@(\w+)\{([\w]+),((?:\W*[a-zA-Z]+\W?=\W?\{.*\},?)*)\W*\},?)");

        /// <summary>
        /// Regex for matching fields within a BibTex item.
        /// </summary>
        readonly Regex _fieldRegex = new Regex(@"([a-zA-Z]+)\W?=\W?\{(.*)\},?");

        public BibtexParser(PaperValidator validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Generates a BibTex file based on the file (Which is given a a string) This file will contain a mapping of common properties of a file (Auther, Year written, etc..) to the respective values  </summary>
        /// <returns>
        /// Returns a bibtex file.</returns>
        public List<Paper> Parse(string file)
        {
            throw new NotImplementedException();
        }

        private Dictionary<EnumField, string> ParsePaper(string data)
        {
            throw new NotImplementedException();
        }
    }
}
