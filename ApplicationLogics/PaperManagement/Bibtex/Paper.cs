using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class Paper
    {
        /// <summary>
        /// The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        public EnumEntry Type;

        /// <summary>
        /// A collection of the item fields and their associated values in the bibliographic item (e.g. Author, Year...)
        /// </summary>
        public readonly IReadOnlyDictionary<EnumField, string> Fields;
        /// <summary>
        /// A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        public int ResourceRef { get; set; }

        public Paper(EnumEntry type, IReadOnlyDictionary<EnumField, string> fields)
        {
            Type = type;
            Fields = fields;
        }
    }

}
