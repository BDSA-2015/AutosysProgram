using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using ApplicationLogics.PaperManagement.Savers;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.StorageAdapter.Interface;
using BibtexLibrary;
using NUnit.Framework;

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
        private readonly ISaver<BibtexFile> _saver;

        public PaperHandler(IParser<BibtexFile> parser, IAdapter<Paper> paperAdapter,
            ISaver<BibtexFile> saver)
        {
            _parser = parser;
            _paperAdapter = paperAdapter;
            _saver = saver;
        }

        /// <summary>
        ///      Parses a given string file to Paper objects for import into the database
        /// </summary>
        /// <param name="file">
        ///      The given file to be parsed to Paper objects for import
        /// </param>
        public void ImportBibtex(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException(nameof(file));
            }
                var papers = _parser.ParseToPapers(file);

                foreach (var paper in papers)
                {
                    _paperAdapter.Create(paper);
                }
        }

        /// <summary>
        ///     Method to save new tags from a file.
        ///     E.g. a bibtex file could be given containing the tags author and book
        ///     these will be stored if they are not already in the database
        /// </summary>
        /// <param name="file"></param>
        public void SaveTags(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentNullException(nameof(file));
            }
            _saver.Save(_parser.ParseToTags(file));
        }
    }
}