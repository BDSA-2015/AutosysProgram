using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for holding bibtex file information to be stored in the database
    /// </summary>
    public class Paper
    {
        /// <summary>
        /// The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        public string Type;

        /// <summary>
        /// A collection of the bibtex fields and their associated values in the bibliographic item (e.g. Author, Year...)
        /// The collection only holds information associated with the default bibtex fields
        /// </summary>
        public readonly IReadOnlyDictionary<string, string> Fields;

        /// <summary>
        /// A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        public int ResourceRef { get; set; }

        /// <summary>
        /// Constructor for creating a Paper based on a bibtex file entry type and fields
        /// </summary>
        /// <param name="type">The type of Paper which is associated with the entry type of the bibtex file it is created from</param>
        /// <param name="fields">Default fields which are being set depending on 
        /// which fields are contained in the associated bibtex file</param>
        public Paper(string type, IReadOnlyDictionary<string, string> fields)
        {
            Type = type;
            Fields = fields;
        }
    }

}
