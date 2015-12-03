﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Storage.Entities;
using Storage.Repository;
using Storage.Repository.Interface;

namespace Storage.Models
{
    
    /// <summary>
    /// This class represents a Criteria entity used to synthesize data in a given study. 
    /// </summary>
    [Table("Criteria")]
    public class StoredCriteria : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)] // Used to delete Criteria in Phase 
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [NotMapped] // Not mapped in database but created dynamically 
        public virtual StoredDataField DataField { get; set; }
    }

}
