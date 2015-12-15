using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Interface for saver classes which are used to save new tags in the database 
    /// when a file with unknown tags is imported into the system
    /// </summary>
    public interface ITagFilter<in T> where T : class 
    {
        /// <summary>
        ///     Saves the data from a file in the database if the data does not exist in the database.
        ///     The data is provided from a parser which parses a given file
        /// </summary>
        /// <param name="data">
        ///     The data to be saved
        /// </param>
        IEnumerable<string> Check(T data);
    }
}
