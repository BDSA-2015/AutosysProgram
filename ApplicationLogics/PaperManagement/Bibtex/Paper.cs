using System.Collections.Generic;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    public class Paper
    {
        /// <summary>
        /// The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        public DefaultEnumEntry Type;

        /// <summary>
        /// A collection of the item fields and their associated values in the bibliographic item (e.g. Author, Year...)
        /// </summary>
        public readonly IReadOnlyDictionary<DefaultEnumField, string> DefaultFields;

        public IDictionary<string, string> CostumFields;
        /// <summary>
        /// A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        public int ResourceRef { get; set; }

        public Paper(DefaultEnumEntry type, IReadOnlyDictionary<DefaultEnumField, string> defaultFields)
        {
            Type = type;
            DefaultFields = defaultFields;
        }
    }

}
