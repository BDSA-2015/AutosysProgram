using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BibtexLibrary;
using BibtexLibrary.Parser;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    ///     Class for passing Bibtex files to Papers based to be saved in the database
    ///     For parsing the imported bibtex files the BibtexLibrary package is used,
    ///     which can be found at: https://github.com/MaikelH/BibtexLibrary
    /// </summary>
    public class BibtexParser : IParser
    {
        private ITagFilter<BibtexFile> _filter;
         
        public BibtexParser()
        {
            _filter = new BibtexTagFilter();
        }

        /// <summary>
        ///     Parses a bibtex file to a Paper.
        ///     The paper will be created with the entry type, field types, the fields values, and the resource key for the bibtex file
        /// </summary>
        /// <param name="file">
        ///     The bibtex file to be parsed
        /// </param>
        /// <returns>
        ///     A collection of Papers if any was parsed from the bibtex file
        ///     Throws an InvalidDataException if the given bibtex file does not follow the defined bibtex syntax
        /// </returns>
        public IEnumerable<Paper> ParseToPapers(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new InvalidDataException($"The content of the parsed file {nameof(file)} do not follow the bibtex syntax");
            }
            try
            {
                var bibfile = BibtexImporter.FromString(@file);
                return
                    bibfile.Entries.Select(
                        bib => new Paper(bib.Type.Trim(), bib.Tags.Keys, bib.Tags.Values) {ResourceRef = bib.Key});
            }
            catch (ParseException e)
            {
                throw new InvalidDataException($"The parsed file {nameof(file)} was not recognized as a bibtex file", e);
            }
        }

        /// <summary>
        ///     Parses bibtex data in a string to find the entry and field type tags in the file
        /// </summary>
        /// <param name="data">
        ///     The given bibtex string to be parsed
        /// </param>
        /// <returns>
        ///     Array of entry and field type tags from a given bibtex file as strings
        /// </returns>
        public string[] ParseToTags(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentNullException(nameof(data));
            }
            return _filter.Check(BibtexImporter.FromString(data)).ToArray();
        }
    }
}