using System;
using ApplicationLogics.PaperManagement.Savers;
using BibtexLibrary;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     This class does the checking of tags in imported files
    ///     to know if the tags are already stored in the database
    ///     or if the file tags need to be saved.
    ///     Example of file tags in a bibtex file book, article, author, year
    /// </summary>
    public class FileTagHandler
    {
        private readonly ISaver<BibtexFile> _saver;
        private readonly IParser<BibtexFile> _parser;

        public FileTagHandler(IParser<BibtexFile> parser, ISaver<BibtexFile> saver)
        {
            _saver = saver;
            _parser = parser;
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
