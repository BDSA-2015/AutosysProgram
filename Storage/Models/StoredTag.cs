﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.Repository.Interface;

namespace Storage.Models
{

    /// <summary>
    /// This entity is used to store references for papers containing a specific tag used when parsing bibtex files. 
    /// </summary>
    public class StoredTag : IEntity
    {

        [Key]
        public int Id { get; set; }

        public virtual ICollection<StoredPaper> PapersContainingTag { get; set; } 

    }

}