namespace ApplicationLogics.PaperManagement.Savers
{
    /// <summary>
    /// Interface for saver classes which are used to save new tags in the database 
    /// when a file with unknown tags is imported into the system
    /// </summary>
    public interface ISaver
    {
        /// <summary>
        /// Saves the tags from a file in the database if the tags does not exist in the database
        /// </summary>
        /// <param name="file"></param>
        void Save(string file);
    }
}
