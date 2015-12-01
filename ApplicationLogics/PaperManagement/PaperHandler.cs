using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    /// Class for handling all functionality associated with creating and importing Papers into the program
    /// </summary>
    public class PaperHandler
    {
        //Used to generate Bibtex files, which later is stored as Papers in the database
        private IParser _parser;

        public PaperHandler(IParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Creates a List of Paper based on an imported BibTex file which is parsed to the program.
        /// </summary>
        /// <param name="file">The bibtex file which is parsed to the program</param>
        /// <returns>A List of Papers which was valid for parsing</returns>
        public List<Paper> ImportPaper(string file)
        {
            throw new NotImplementedException();
        }
       
    }
}
