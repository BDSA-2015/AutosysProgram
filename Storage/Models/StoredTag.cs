using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;

namespace Storage.Models
{

    /// <summary>
    /// This entity is used to store references for papers containing a specific tag used when parsing bibtex files. 
    /// </summary>
    public class StoredTag
    {

        [Key]
        public int Id { get; set; }

        public ICollection<StoredPaper> PapersContainingTag { get; set; } 

    }

}
