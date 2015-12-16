using System.Collections.Generic;
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

        #region Paper entities 

        /// <summary>
        ///     The Entry type of the bibliographic item (e.g. Article, Book, Phdthesis...)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     A reference to the resource associated with this Paper (e.g. A PDF, or CSV file...)
        /// </summary>
        [StringLength(100)]
        public string ResourceRef { get; set; }

        #endregion

        #region Referenced entities 

        /// <summary>
        ///     A collection of bibtex field types (e.g. Author, Year...)
        ///     The collection holds information associated with the bibtex field values in the FieldValues collection
        /// </summary>
        public virtual ICollection<string> FieldTypes { get; set; } 

        /// <summary>
        ///     A collection of bibtex field values (e.g. Henrik Madsen, 2015)
        ///     The collection holds information associated with the bibtex field types in the FieldTypes collection
        /// </summary>
        public virtual ICollection<string> FieldValues { get; set; } 

        /// <summary>
        ///     A collection of custom made data fields holding information related to a specific Paper
        /// </summary>
        public virtual ICollection<StoredDataField> RequesteDataFields { get; set; }

        #endregion

        #region Keys 

        public virtual StoredStudy Study { get; set; }

        [Key]
        public int Id { get; set; }

        #endregion

    }

}