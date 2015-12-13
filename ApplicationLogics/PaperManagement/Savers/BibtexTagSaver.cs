using System;
using System.Collections.Generic;
using ApplicationLogics.StorageAdapter.Interface;
using BibtexLibrary;

namespace ApplicationLogics.PaperManagement.Savers
{
    /// <summary>
    /// This class has responsibility for checking if the entry and field types of a given bibtex file
    /// is already stored in the database. If the entry and field types are new they will be stored in the database as StoredBibtexTags.
    /// </summary>
    public class BibtexTagSaver : ISaver<BibtexFile>
    {
        private IAdapter<BibtexTag> _bibtexAdapter;
         
        public BibtexTagSaver(IAdapter<BibtexTag> bibtexAdapter)
        {
            _bibtexAdapter = bibtexAdapter;
        }
        /// <summary>
        /// Method for saving bibtex entries which are not yet stored in the database
        /// </summary>
        /// <param name="entryType">The given bibtex file entry type</param>
        public void Save(BibtexFile entryType)
        {
            throw new NotImplementedException();
        }
    }
}
