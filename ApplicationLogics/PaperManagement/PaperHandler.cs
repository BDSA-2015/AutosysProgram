using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement
{
    public class PaperHandler
    {
        //is used to generate Bibtex files, which later can be stored as a Paper
        private IParser parser { get; set; }
        /// <summary>
        /// Create a empty Paper
        /// </summary>
        public Paper CreatePaper()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a Paper based on a BibTex file.
        /// </summary>
        /// <param name="file"></param>
        public Paper CreatePaper(BibTexFile file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a Paper based on a document
        /// </summary>
        /// <param name="document"></param>
        /// <returns> Paper based on a automaed analysis of the file</returns>
        public Paper LoadFile(string document)
        {
            throw new NotImplementedException();
        }
       
    }
}
