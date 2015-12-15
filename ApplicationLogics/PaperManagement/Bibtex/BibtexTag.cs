namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// This class represents a bibtex tag which can both be an entry e.g. article or book and also a field type e.g. author or year.
    /// A bibtex tag is created from a bibtex file and stored as a StoredBibtexTag in the database
    /// </summary>
    public class BibtexTag
    {
        /// <summary>
        /// Type of the bibtex tag e.g. article, book, author, or year
        /// </summary>
        public string Type { get; set; }
    }
}
