using Storage.Models;

namespace ApplicationLogics.StudyManagement
{
    /// <summary>
    ///     Represents data of one user provided for a <see cref="DataField" />, used to indicate conflicting data between users.
    /// </summary>
    public class Conflict
    {
        /// <summary>
        ///     The user ID of the user who provided the data.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     The data provided by the user.
        /// </summary>
        public string[] Data { get; set; }
    }
}