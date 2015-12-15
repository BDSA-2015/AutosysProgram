using System.Collections.Generic;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.PaperManagement
{
    /// <summary>
    ///     Class for holding bibtex file information to be stored in the database
    /// </summary>
    public class Paper
    {
        /// <summary>
        ///     The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        public readonly string Type;

        /// <summary>
        ///     A collection of bibtex field types (e.g. Author, Year...)
        ///     The collection holds information associated with the bibtex field values in the FieldValues collection
        /// </summary>
        public readonly IReadOnlyCollection<string> FieldTypes;

        /// <summary>
        ///     A collection of bibtex field values (e.g. Henrik Madsen, 2015)
        ///     The collection holds information associated with the bibtex field types in the FieldTypes collection
        /// </summary>
        public readonly IReadOnlyCollection<string> FieldValues;

        /// <summary>
        ///     A collection of custom made data fields holding information related to a specific Paper
        /// </summary>
        public ICollection<DataField> RequesteDataFields { get; }

        /// <summary>
        ///     Constructor for creating a Paper based on a bibtex file entry type and fields
        /// </summary>
        /// <param name="type">
        ///     The type of Paper which is associated with the entry type of the bibtex file it is created from
        /// </param>
        /// <param name="resourceRef">
        ///     The unique key of a single Paper related to a single bibtex entry
        /// </param>
        /// <param name="fieldTypes">
        ///     Collection of bibtex fieldtypes from an imported bibtex file
        ///     which fields are contained in the associated bibtex file
        /// </param>
        /// <param name="fieldValues">
        ///     Collection of bibtex field values associated with a field type from an imported bibtex file
        /// </param>
        public Paper(string type, IReadOnlyCollection<string> fieldTypes, IReadOnlyCollection<string> fieldValues)
        {
            Type = type;
            FieldTypes = fieldTypes;
            FieldValues = fieldValues;
            RequesteDataFields = new List<DataField>();
        }

        /// <summary>
        ///     A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        public string ResourceRef { get; set; }
    }
}