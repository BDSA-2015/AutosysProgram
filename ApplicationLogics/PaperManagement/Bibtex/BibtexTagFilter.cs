using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BibtexLibrary;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// This class has responsibility for checking if the entry and field types of a given bibtex file
    /// is already stored in the database. If the entry and field types are new they will be stored in the database as StoredBibtexTags.
    /// </summary>
    public class BibtexTagFilter : ITagFilter<BibtexFile>
    {
        private ICollection<BibtexEntry> _dataEntries;
        private List<BibtexTag> _bibtexNewTags;   

        /// <summary>
        /// Method for saving bibtex entries which are not yet stored in the database
        /// </summary>
        /// <param name="data">The given bibtex file entry type</param>
        public IEnumerable<string> Check(BibtexFile data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (data.Entries.Count < 1)
            {
                throw new InvalidDataException($"The bibtex file {nameof(data)} was empty");
            }

            _dataEntries = data.Entries;
            _bibtexNewTags = new List<BibtexTag>();

            FindEntryTypes();
            FindFieldTypes();

            if (_bibtexNewTags.Count <= 0) yield break;
            foreach (var tag in _bibtexNewTags)
            {
                yield return tag.Type;
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
        private void FindEntryTypes()
        {
            foreach (var entry in _dataEntries)
            {
                var entryType = entry.Type;
                    if (!_bibtexNewTags.Any(r => r.Type.Equals(entryType)))
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
        private void FindFieldTypes()
        {
            foreach (var entry in _dataEntries)
            {
                var fieldTypes = entry.Tags.Keys;

                foreach (var type in fieldTypes)
                {
                    if (!_bibtexNewTags.Any(r => r.Type.Equals(type)))
                    {
                        _bibtexNewTags.Add(new BibtexTag() { Type = type });
                    }
                }
            }
        }
    }
}
