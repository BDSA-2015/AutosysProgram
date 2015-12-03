using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogics.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for creating custom made entries for parsing bibtex files defined by the client
    /// </summary>
    public class CustomEntry
    {
        //Holds custom made entry values defined by a client
        private List<string> _entries;

        public CustomEntry(List<string> entries)
        {
            _entries = entries;
        }

        /// <summary>
        /// Validates
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public bool ContainsEntry(string entry)
        {
            return _entries.All(r => r.Equals(entry));
        }

    }
}
