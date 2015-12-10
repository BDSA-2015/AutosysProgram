using System.Collections.Generic;
using System.IO;
using System.Linq;
using BibtexLibrary;
using BibtexLibrary.Parser;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    /// Class for passing Bibtex files to Papers based to be saved in the database
    /// For parsing the imported bibtex files the BibtexLibrary package is used,
    /// which can be found at: https://github.com/MaikelH/BibtexLibrary
    /// </summary>
    public class BibtexParser : IParser
    {
        public IEnumerable<Paper> Parse(string file)
        {
            try
            {
                var bibFile = BibtexImporter.FromString(@file);
                return bibFile.Entries.Select(bib => new Paper(bib.Type.Trim(), bib.Tags.Keys, bib.Tags.Values) { ResourceRef = bib.Key });
            }
            catch (ParseException e)
            {
                throw new InvalidDataException($"The parsed file was not recognized as a bibtex file", e);
            }
                 
        }
    }
}
