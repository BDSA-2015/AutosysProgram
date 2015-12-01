using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.PaperManagement.Interfaces;
using ApplicationLogics.Repository;

namespace ApplicationLogics.PaperManagement
{
    public class PaperHandler
    {
        //is used to generate Bibtex files, which later can be stored as a Paper
        private IParser _parser;

        public PaperHandler(IParser parser)
        {
            _parser = parser;
        }

        /// <summary>
        /// Create an empty Paper
        /// </summary>
        public Paper CreatePaper()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a Paper based on a BibTex file.
        /// </summary>
        /// <param name="file"></param>
        public Paper ImportPaper(string file)
        {
            throw new NotImplementedException();
        }

        //Extra Stuff
        /// <summary>
        /// Create a Paper based on a document
        /// </summary>
        /// <param name="document"></param>
        /// <returns> Paper based on an automated analysis of the file</returns>
        public Paper GeneratePaper(string document)
        {
            throw new NotImplementedException();
        }
       
    }
}
