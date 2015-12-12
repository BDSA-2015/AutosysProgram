using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     Class for holding bibtex file information to be stored in the database
    /// </summary>
    public class Paper
    {
        /// <summary>
        ///     A collection of the bibtex field types (e.g. Author, Year...)
        ///     The collection only holds information associated with the default bibtex field types
        /// </summary>
        public readonly IReadOnlyCollection<string> FieldTypes;

        public readonly IReadOnlyCollection<string> FieldValues;

        /// <summary>
        ///     The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        public string Type;

        /// <summary>
        ///     Constructor for creating a Paper based on a bibtex file entry type and fields
        /// </summary>
        /// <param name="type">The type of Paper which is associated with the entry type of the bibtex file it is created from</param>
        /// <param name="fieldTypes">
        ///     Collection of bibtex fieldtypes from an imported bibtex file
        ///     which fields are contained in the associated bibtex file
        /// </param>
        /// <param name="fieldValues">Collection of bibtex field values associated with a field type from an imported bibtex file</param>
        public Paper(string type, IReadOnlyCollection<string> fieldTypes, IReadOnlyCollection<string> fieldValues)
        {
            Type = type;
            FieldTypes = fieldTypes;
            FieldValues = fieldValues;
        }

        /// <summary>
        ///     A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        public string ResourceRef { get; set; }

        public int Id { get; set; }
    }
}