// BibtexParser.cs is a part of Autosys project in BDSA-2015. Created: 17, 11, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using ApplicationLogics.PaperManagement.Interfaces;

namespace ApplicationLogics.PaperManagement
{
    public class BibtexParser : IParser
    {
        /// <summary>
        /// Generates a BibTex file based on the input file (given as a string).
        /// This file will contain a mapping of common tag properties of a file (Auther, Year written, etc..) with their respective values. 
        /// </summary>
        /// <returns>
        /// Returns a bibtex file.
        /// </returns>
        public IFile Parse(string file)
        {
            throw new NotImplementedException();
        }

    }

}