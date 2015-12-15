using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents a BibtexTag entity.
    ///     The BibtexTag is used to select inclusion and exclusion criteria for Papers in a Study through the Study Configuration UI.
    /// </summary>
    [Table("BibtexTag")]
    public class StoredBibtexTag : IEntity
    {
        [Required]
        public string Type { get; set; } //Can be both entries and field types e.g. Book, Author, and Year

        [Key]
        public int Id { get; set; }
    }
}
