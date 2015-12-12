using System;

namespace ApplicationLogics.PaperManagement.Savers
{
    /// <summary>
    /// This class has responsibility for checking if the entry and field types of a given bibtex file
    /// is already stored in the database. If the entry and field types are new they will be stored in the database as StoredBibtexTags.
    /// </summary>
    public class BibtexTagSaver : ISaver
    {
        /// <summary>
        /// Method for saving bibtex entries and fields which are not yet stored in the database
        /// </summary>
        /// <param name="file">The given bibtex file containing the entry and field types to be stored</param>
        public void Save(string file)
        {
            throw new NotImplementedException();
        }
    }
}
