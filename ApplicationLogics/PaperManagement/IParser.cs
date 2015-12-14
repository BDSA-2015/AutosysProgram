using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     Interface for Parsers used to parsing files into the program
    /// </summary>
    public interface IParser<T> where T : class 
    {
        /// <summary>
        ///     Method for parsing imported files as strings
        /// </summary>
        /// <param name="data">
        ///     The file to be parsed
        /// </param>
        /// <returns>
        ///     A collection of Papers holding information according to the parsed file
        /// </returns>
        IEnumerable<Paper> ParseToPapers(string data);

        /// <summary>
        ///     Parses the given string to a file object of the specified type
        /// </summary>
        /// <param name="data">
        ///     The string to be parsed
        /// </param>
        /// <returns>
        ///     A file object e.g. BibtexFile
        /// </returns>
        T ParseToFile(string data);
    }
}