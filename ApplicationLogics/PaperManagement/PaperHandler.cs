// PaperHandler.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement
{

    /// <summary>
    /// This class is used to create papers based on e.g. a BibTex file or other document types. 
    /// </summary>
    public class PaperHandler
    {
        // Used to generate Bibtex files later stored as a Paper
        private IParser parser { get; set; }

        /// <summary>
        /// Create a empty Paper.
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
        /// <param name="document">
        /// Document used to create a paper. 
        /// </param>
        /// <returns> 
        /// Paper based on an automated analysis of the file
        /// </returns>
        public Paper LoadFile(string document)
        {
            throw new NotImplementedException();
        }
    }
}