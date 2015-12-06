using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.Repository.Interface;

namespace Storage.Models
{

    /// <summary>
    /// This entity is used to store papers containing a given entry field from parsing a bibtex file. 
    /// </summary>
    public class StoredEntry : IEntity
    {

        [Key]
        public int Id { get; set; }

        public virtual ICollection<StoredPaper> PapersContainingEntry { get; set; }

    }
    
}
