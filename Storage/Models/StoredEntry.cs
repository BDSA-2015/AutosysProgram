using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;

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
