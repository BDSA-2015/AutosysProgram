using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Storage.Repository.Interface;

namespace Storage.Models
{
    /// <summary>
    ///     This class represents entity used to store a study, the whole work process from initiating a research to narrowing
    ///     down relevant research evidence.
    ///     A study consists of diﬀerent phases where data is continuously synthesized and approved by users with different
    ///     roles.
    /// </summary>
    public class StoredStudy : IEntity
    {
        
        #region Study Properties 

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        #endregion

        #region Referenced entities 

        /// <summary>
        ///     The papers which are included in the project.
        ///     Papers are imported from a file (e.g. a bibtex file) which loaded into the program by a client
        /// </summary>
        public virtual ICollection<StoredPaper> Papers { get; set; }

        /// <summary>
        ///     The data fields defined for a study.
        ///     These data fields will be distributed to tasks which will be associated with each paper in the study.
        /// </summary>
        public virtual ICollection<StoredDataField> DataFields { get; set; }

        /// <summary>
        ///     This list contains Criteria, which each report cannot contain.
        /// </summary>
        public virtual ICollection<StoredCriteria> ExclusionCriteria { get; set; }

        /// <summary>
        ///     This list contains Criteria, which each report must contain.
        /// </summary>
        public virtual ICollection<StoredCriteria> InclusionCriteria { get; set; }

        /// <summary>
        ///     A list of all the users who are working on the study
        /// </summary>
        public virtual ICollection<StoredUser> Users { get; set; } // Previously list of user ids 

        /// <summary>
        ///     Phases that the study has undergone and the current phase.
        /// </summary>
        public virtual ICollection<StoredPhase> Phases { get; set; }

        #endregion

        #region Keys 

        [Key]
        public int Id { get; set; }

        #endregion 

    }

}