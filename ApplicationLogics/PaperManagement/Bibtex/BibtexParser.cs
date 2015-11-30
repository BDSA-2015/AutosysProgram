using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class BibtexParser : IParser
    {
        readonly PaperValidator _validator;

        /// <summary>
        /// Regex for matching BibTex Entries.
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
            //Most of the code is from AS1 BDSA 2015
            MatchCollection matchCollection = _entryRegex.Matches(file);

            var papers = new List<Paper>();

            foreach (Match match in matchCollection)
            {
                try
                {
                    string key = match.Groups[2].Value;
                    EnumEntry type = (EnumEntry)Enum.Parse(typeof(EnumEntry), match.Groups[1].Value, true);
                    Dictionary<EnumField, string> fields = ParsePaper(match.Groups[3].Value);
                    var paper = new Paper(type, fields);

                    if (!_validator.IsPaperValid(paper))
                    {
                        throw new InvalidDataException($"The Paper with key {key} is not valid");
                    }

                    papers.Add(paper);
                }
                catch (ArgumentException e)
                {
                    throw new InvalidDataException($"The Paper type {match.Groups[1].Value} is not known by the parser", e);
                }
            }

            return papers;
        }

        private Dictionary<EnumField, string> ParsePaper(string data)
        {
            //Most of the code is from AS1 in BDSA 2015
            var matchCollection = _fieldRegex.Matches(data);

            
            var fields = new Dictionary<EnumField, string>();

            // Iterate over every field.
            foreach (Match match in matchCollection)
            {
                try
                {
                    // Get the field type and value.
                    var key = (EnumField)Enum.Parse(typeof(EnumField), match.Groups[1].Value, true);
                    var value = match.Groups[2].Value;

                    fields.Add(key, value);
                }
                catch (ArgumentException e)
                {
                    throw new InvalidDataException(
                        $"The field type {match.Groups[1].Value} is not known by the parser", e);
                }
            }

            return fields;
        }
    }
}
