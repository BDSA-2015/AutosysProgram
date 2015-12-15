using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using BibtexLibrary;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     Class for handling all functionality associated with creating and importing Papers into the program
    /// </summary>
    public class PaperHandler
    {
        private readonly IAdapter<Paper> _paperAdapter;
        //Used to generate Bibtex files, which later is stored as Papers in the database
        private readonly IParser<BibtexFile> _parser;

        public PaperHandler(IParser<BibtexFile> parser, IAdapter<Paper> paperAdapter)
        {
            _parser = parser;
            _paperAdapter = paperAdapter;
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
        public IEnumerable<Paper> ParseFile(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException(nameof(file));
            }

            return _parser.ParseToPapers(file);
        }
    }
}