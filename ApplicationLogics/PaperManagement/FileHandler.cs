using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using BibtexLibrary;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     Class for handling all functionality associated with creating and importing Papers into the program
    /// </summary>
    public class FileHandler
    {
        //Used to generate Bibtex files, which later is stored as Papers in the database
        private readonly IParser _parser;

        public FileHandler(IParser parser)
        {
            _parser = parser;
        }

        ///<summary>
        ///      Parses a given string file to Paper objects used in a specific Study
        /// </summary>
        /// <param name="file">
        ///      The given file to be parsed to Paper objects
        /// </param>
        /// <returns>
        ///     A collection of Papers to be used in a chosen Study
        /// </returns>
        public IEnumerable<Paper> ParseToPapers(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException(nameof(file));
            }

            return _parser.ParseToPapers(file);
        }

        /// <summary>
        ///     Method to save new tags from a file.
        ///     E.g. a bibtex file could be given containing the tags author and book
        ///     these will be stored if they are not already in the database
        /// </summary>
        /// <param name="file"></param>
        public string[] ParseTags(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException(nameof(file));
            }
            return _parser.ParseToTags(file);
        }
    }
}