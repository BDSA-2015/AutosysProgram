namespace Storage.Models
{
    /// <summary>
    ///     Represents data of one user provided for a <see cref="StoredDataField" />, used to indicate conflicting data between users.
    /// </summary>
    public class StoredConflict
    {
        /// <summary>
        ///     The user ID of the user who provided the data.
        /// </summary>
        public int UserId { get; set; } 

        /// <summary>
        /// The user who provided the data. 
        /// </summary>
        public virtual StoredUser User { get; set; }

        /// <summary>
        ///     The data provided by the user.
        /// </summary>
        public string[] Data { get; set; }
    }

}