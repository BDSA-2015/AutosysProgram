using ApplicationLogics.PaperManagement.Bibtex;

namespace ApplicationLogics.PaperManagement.Interfaces
{
    /// <summary>
    /// Interface for all field checkers used for validating fields of different imported files
    /// </summary>
    public interface IFieldChecker
    {
        /// <summary>
        /// Validates a field of some imported file which is to be parsed in the program
        /// </summary>
        /// <param name="field">The field to be validated for parsing</param>
        /// <returns>True if the field is valid false otherwise</returns>
        bool Validate(string field);
    }
}
