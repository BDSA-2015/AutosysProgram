﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents a paper entity used to store information based on tags in a given bibtex file with many
    ///     papers.
    /// </summary>
    [Table("Paper")]
    public class StoredPaper : IEntity
    {

        /// <summary>
        ///     The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        ///     A collection of bibtex field types (e.g. Author, Year...)
        ///     The collection holds information associated with the bibtex field values in the FieldValues collection
        /// </summary>
        [Required]
        public virtual ICollection<string> FieldTypes { get; set; } // TODO map to IReadOnlyCollection in logic 

        /// <summary>
        ///     A collection of bibtex field values (e.g. Henrik Madsen, 2015)
        ///     The collection holds information associated with the bibtex field types in the FieldTypes collection
        /// </summary>
        [Required]
        public virtual ICollection<string> FieldValues { get; set; } // TODO map to IReadOnlyCollection in logic 

        /// <summary>
        ///     A collection of custom made data fields holding information related to a specific Paper
        /// </summary>
        public virtual ICollection<StoredDataField> RequesteDataFields { get; set; }

        /// <summary>
        ///     A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        [StringLength(100)]
        [Required]
        public string ResourceRef { get; set; }

        [Key]
        public int Id { get; set; }

    }

}