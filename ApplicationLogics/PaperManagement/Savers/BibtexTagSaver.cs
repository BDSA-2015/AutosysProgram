using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IAdapter<BibtexTag> _bibtexAdapter;
        private ICollection<BibtexEntry> _dataEntries;
        private List<BibtexTag> _bibtexTags;
        private List<BibtexTag> _bibtexNewTags;   

        public BibtexTagSaver(IAdapter<BibtexTag> bibtexAdapter)
        {
            _bibtexAdapter = bibtexAdapter;
        }
        /// <summary>
        /// Method for saving bibtex entries which are not yet stored in the database
        /// </summary>
        /// <param name="data">The given bibtex file entry type</param>
        public void Save(BibtexFile data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _dataEntries = data.Entries;
            _bibtexTags = _bibtexAdapter.Read().ToList();
            _bibtexNewTags = new List<BibtexTag>();

            SaveEntryTypes();
            SaveFieldTypes();

            if (_bibtexNewTags.Count > 0)
            {
                foreach (var tag in _bibtexNewTags)
                {
                    _bibtexAdapter.Create(tag);
                }
            }
        }

        /// <summary>
        ///     Saves all bibtex entry types e.g. Book, Article... from a BibtexFile if they are not yet stored in the database
        /// </summary>
        /// <param name="dataEntries">
        ///     The Bibtex Entries from which to save the types
        /// </param>
        /// <param name="bibtexTags">
        ///     The bibtex tags already stored in the database
        /// </param>
        private void SaveEntryTypes()
        {
            foreach (var entry in _dataEntries)
            {
                var entryType = entry.Type;
                    if (!_bibtexTags.Any(r => r.Type.Equals(entryType)) && 
                    !_bibtexNewTags.Any(r => r.Type.Equals(entryType)))
                    {
                        _bibtexNewTags.Add(new BibtexTag() {Type = entryType});
                    }
            }
        }

        /// <summary>
        ///     Saves all field types e.g. author, year, title... from a BibtexFile if they are not yet stored in the database
        /// </summary>
        /// <param name="dataEntries">
        ///     The Bibtex Entries from which to save the types
        /// </param>
        /// <param name="bibtexTags">
        ///     The bibtex tags already stored in the database
        /// </param>
        private void SaveFieldTypes()
        {
            foreach (var entry in _dataEntries)
            {
                var fieldTypes = entry.Tags.Keys;

                foreach (var type in fieldTypes)
                {
                    if (!_bibtexTags.Any(r => r.Type.Equals(type)) &&
                        !_bibtexNewTags.Any(r => r.Type.Equals(type)))
                    {
                        _bibtexNewTags.Add(new BibtexTag() { Type = type });
                    }
                }
            }
        }
    }
}
