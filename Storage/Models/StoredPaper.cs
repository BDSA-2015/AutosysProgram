using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Storage.Repository.Interface;

namespace Storage.Models
{

    /// <summary>
    /// This class represents a paper entity used to store information based on tags in a given bibtex file with many papers. 
    /// </summary>
    [Table("Paper")]
    public class StoredPaper : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(400)]
        [Required]
        public string Type { get; set; }

        [StringLength(400)]
        [Required]
        public string Author { get; set; }

        [StringLength(400)]
        [Required]
        public string Title { get; set; }

        [StringLength(400)]
        [Required]
        public string BookTitle { get; set; }

        [Required]
        public int Year { get; set; }

        public string Month { get; set; } 

        [StringLength(400)]
        public string Volume { get; set; }

        public int Pages { get; set; }

        [StringLength(400)]
        public string Abstract { get; set; }

        [StringLength(50)]
        public string Doi { get; set; } 

        [StringLength(50)]
        public string ISSN { get; set; } 

    }

}
