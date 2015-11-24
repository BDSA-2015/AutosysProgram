using System;

namespace ApplicationLogics.PaperManagement
{
    public class BibtexParser : IParser
    {
        /// <summary>
        /// Generates a BibTex file based on the file (Which is given a a string) This file will contain a mapping of common properties of a file (Auther, Year written, etc..) to the respective values  </summary>
        /// <returns>
        /// Returns a bibtex file.</returns>
        public IFile Parse(string file)
        {
            throw new NotImplementedException();
        }
    }
}
