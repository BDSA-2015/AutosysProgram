using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{

    /// <summary>
    /// This entity is used to store papers containing a given entry field from parsing a bibtex file. 
    /// </summary>
    public class StoredEntry
    {

        [Key]
        public int Id { get; set; }

        public virtual ICollection<StoredPaper> PapersContainingEntry { get; set; }

    }
    
}
