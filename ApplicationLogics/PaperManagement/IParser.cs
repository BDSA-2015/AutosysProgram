using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     Interface for Parsers used to parsing files into the program
    /// </summary>
    public interface IParser
    {
        /// <summary>
        ///     Method for parsing imported files as strings
        /// </summary>
        /// <param name="data">The file to be parsed</param>
        /// <returns>A list of Papers holding information according to the parsed file</returns>
        IEnumerable<Paper> Parse(string data);
    }
}