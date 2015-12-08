﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for passing Bibtex files to Papers based to be saved in the database
    /// </summary>
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
        /// Generates a BibTex file based on the file (Which is given a a string) 
        /// This file will contain a mapping of common properties of a file (Auther, Year written, etc..) 
        /// to the respective values  </summary>
        /// <returns> Returns a List of Papers which matched the entry and field regexes.</returns>
        public List<Paper> Parse(string file)
        {
            if (!_entryRegex.IsMatch(file))
            {
                throw new InvalidDataException($"The bibtex file {file} does not follow the bibtex syntax");
            }
            //Most of the code is from AS1 BDSA 2015
            MatchCollection matchCollection = _entryRegex.Matches(file);

            var papers = new List<Paper>();

            foreach (Match match in matchCollection)
            {
                try
                {
                    string key = match.Groups[2].Value;
                    string entry = match.Groups[1].Value;
                    List<List<string>> fields = ParsePaper(match.Groups[3].Value);
                    var paper = new Paper(entry, fields[0], fields[1]);
                    paper.ResourceRef = key;

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

        /// <summary>
        /// Helper method for verifying the bibtex fields of a Paper to see if the Paper should be parsed
        /// </summary>
        /// <param name="fieldData">Bibtex field data associated with a specific bibtex item</param>
        /// <returns></returns>
        private List<List<string>> ParsePaper(string fieldData)
        {
            //Most of the code is from AS1 in BDSA 2015
            var matchCollection = _fieldRegex.Matches(fieldData);

            
            var fields = new List<List<string>>() {new List<string>(), new List<string>()};

            // Iterate over every field.
            foreach (Match match in matchCollection)
            {
                try
                {
                    // Get the field type and value.
                    var type = match.Groups[1].Value;
                    var value = match.Groups[2].Value;

                    fields[0].Add(type);
                    fields[1].Add(value);
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