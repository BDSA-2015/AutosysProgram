using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.PaperManagement.Bibtex;

namespace ApplicationLogics.PaperManagement.Interfaces
{
    /// <summary>
    /// Interface for Paper checkers
    /// </summary>
    public interface IPaperChecker
    {
        /// <summary>
        /// Checks if a given Paper is valid
        /// </summary>
        /// <param name="paper">The Paper to validate</param>
        /// <returns>True when the given Paper is valid and false otherwise</returns>
        bool Validate(Paper paper);
    }
}
