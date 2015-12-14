using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;
using ApplicationLogics.StorageAdapter;
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

        /// <summary>
        ///     Creates a List of Paper based on an imported BibTex file which is parsed to the program.
        /// </summary>
        /// <param name="file">The bibtex file which is parsed to the program</param>
        /// <returns>A List of Papers which was valid for parsing</returns>
        public IEnumerable<Task<int>> ImportBibtex(string file)
        {
            if (file.IsEmpty() || file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            return _parser.ParseToPapers(file).Select(paper => _paperAdapter.Create(paper));
        }

        public void SaveTags()
        {
            throw new NotImplementedException();
        }
    }
}