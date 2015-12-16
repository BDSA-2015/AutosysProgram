using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    /// <summary>
    ///     Represents data of one user provided for a <see cref="StoredDataField" />, used to indicate conflicting data between users.
    /// </summary>
    public class StoredConflict
    {
        #region Properties 

        /// <summary>
        ///     The data provided by the user. Each responded field is saved as a new string entry. 
        /// </summary>
        public ICollection<string> Data { get; set; }

        ///// <summary>
        /////     The user ID of the user who provided the data.
        ///// </summary>
        //public int UserId { get; set; }

        #endregion

        #region Keys 

        /// <summary>
        /// The user who provided the data. 
        /// </summary>
        public virtual StoredUser User { get; set; }

        public virtual TaskConflicts FieldConflicts { get; set; }

        [Key]
        public int Id { get; set; }

        #endregion

    }

}